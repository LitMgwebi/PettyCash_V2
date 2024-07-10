﻿using PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService;

namespace PettyCashPrototype.Services.RequisitionService
{
    public class RequisitionService: IRequisition
    {
        private PettyCashPrototypeContext _db;
        private readonly IUser _user;
        private readonly IGLAccount _glAccount;
        private readonly IJobTitle _jobTitle;
        public RequisitionService(PettyCashPrototypeContext db, IUser user, IGLAccount gLAccount, IJobTitle jobTitle) { 
            _db = db;
            _user = user;
            _glAccount = gLAccount;
            _jobTitle = jobTitle;
        }

        public async Task<IEnumerable<Requisition>> GetAll()
        {
            try
            {
                IEnumerable<Requisition> requisitions = await _db.Requisitions
                    .Where(a => a.IsActive == true)
                    .ToListAsync();

                if (requisitions == null) throw new Exception("System could not find any requisitions.");
                return requisitions;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Requisition>> GetAllForManagerApproval(int divisionId)
        {
            try
            {
                IEnumerable<Requisition> requisitions = await _db.Requisitions
                    .Include(a => a.Applicant)
                    .Where(a => a.IsActive == true)
                    .Where(d => d.Applicant!.DivisionId == divisionId)
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .ToListAsync();

                if (requisitions == null) throw new Exception("System could not find any requisitions.");
                return requisitions;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Requisition>> GetAllForFinanceApproval(int divisionId, int jobTitleId)
        {
            try
            {
                JobTitle jobTitle = await _jobTitle.GetOne(jobTitleId);
                IEnumerable<Requisition> requisitions = new List<Requisition>();
                if (divisionId == 6)
                {

                    IFinanceApproval Deputy = new Deputy(_db);
                    IFinanceApproval Manager = new Manager(_db);
                    IFinanceApproval CFO = new CFO(_db);

                    CFO.SetNext(Manager);
                    Manager.SetNext(Deputy);

                    requisitions = await CFO.GetRequisitions(jobTitle.Description);
                }
                else
                    throw new Exception("You have to be in the Finance Department to approve of this requisitions.");

                if (requisitions == null) throw new Exception("System could not find any requisitions.");
                return requisitions;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Requisition>> GetByApplicant(string id)
        {
            try
            {
                IEnumerable<Requisition> requisitions = await _db.Requisitions
                    .Where(a => a.ApplicantId == id)
                    .Include(a => a.Applicant)
                    .Where(a => a.IsActive == true)
                    .ToListAsync();

                if (requisitions == null) throw new Exception("System could not find any of your requisition forms.");
                return requisitions;
            }
            catch { throw; }
        }

        public async Task<Requisition> GetOne(int id)
        {
            try
            {
                Requisition requisition= await _db.Requisitions
                    .Where(a => a.IsActive == true)
                    .Include(z => z.Applicant)
                    .SingleAsync(i => i.RequisitionId == id);

                if (requisition == null) throw new Exception("System could not retrieve the Requisition requested.");
                return requisition;
            }
            catch { throw; }
        }

        public async Task Create(Requisition requisition)
        {
            try
            {
                requisition.Applicant = await _user.GetUserById(requisition.ApplicantId);
                requisition.Glaccount = await _glAccount.GetOne(requisition.GlaccountId);
                _db.Requisitions.Add(requisition);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException("System could not add the new Requisition.");
            }
            catch { throw; }
        }

        public void Edit(Requisition requisition)
        {
            try
            {
                _db.Requisitions.Update(requisition);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not edit the requisition for {requisition.Applicant}.");
            }
            catch { throw; }
        }

        public void SoftDelete(Requisition requisition)
        {
            try
            {
                requisition.IsActive = false;
                _db.Requisitions.Update(requisition);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not delete the requested requisition.");
            }
            catch { throw; }
        }
    }
}
