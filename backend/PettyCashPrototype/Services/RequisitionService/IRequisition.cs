namespace PettyCashPrototype.Services.RequisitionService
{
    public interface IRequisition
    {
        public Task<IEnumerable<Requisition>> GetAll(string purpose, int divisionId, int jobTitleId, string userId, string role);
        public Task<Requisition> GetOne(int id);
        public Task<string> Create(Requisition requisition, string userId);
        public Task<string> Edit(Requisition requisition, string command, string userId = "");
        public void SoftDelete(Requisition requisition);
    }
}
