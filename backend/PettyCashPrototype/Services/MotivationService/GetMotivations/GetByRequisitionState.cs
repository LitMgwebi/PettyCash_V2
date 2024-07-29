namespace PettyCashPrototype.Services.MotivationService.GetMotivations
{
    public class GetByRequisitionState : IMotivationsState
    {
        public async Task<IEnumerable<Motivation>> GetMotivations(PettyCashPrototypeContext db, int requisitionId)
        {
            IEnumerable<Motivation> motivations = await db.Motivations
                .Where(x => x.IsActive == true)
                .Where(r => r.RequisitionId == requisitionId)
                .AsNoTracking()
                .ToListAsync();

            if (motivations == null)
                throw new Exception("System could not find the motivations for this requisition.");

            return motivations;
        }
    }
}
