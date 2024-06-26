namespace PettyCashPrototype.Services.RequisitionService
{
    public interface IRequisition
    {
        public Task<IEnumerable<Requisition>> GetAll();
        public Task<IEnumerable<Requisition>> GetAllForManagerApproval();
        public Task<IEnumerable<Requisition>> GetByApplicant(string id);
        public Task<Requisition> GetOne(int id);
        public Task Create(Requisition requisition);
        public void Edit(Requisition requisition);
        public void SoftDelete(Requisition requisition);
    }
}
