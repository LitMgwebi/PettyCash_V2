namespace PettyCashPrototype.Services.RequisitionService
{
    public interface IRequisition
    {
        public Task<IEnumerable<Requisition>> GetAll(string command, int divisionId = 0, int jobTitleId = 0, string userId = "", string role = "", int status = 0);
        public Task<Requisition> GetOne(int id);
        public Task<string> Create(Requisition requisition, string userId);
        public Task<string> Edit(Requisition requisition, string command, string userId = "", int attemptCode = 0, bool forDoc = false);
        public Task SoftDelete(Requisition requisition);
    }
}
