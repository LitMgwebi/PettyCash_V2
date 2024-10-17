namespace PettyCashPrototype.Services.StatusService
{
    public interface IStatus
    {
        public Task<IEnumerable<Status>> GetAll();
        public Task<IEnumerable<Status>> GetApproved();
        public Task<IEnumerable<Status>> GetRecommended();
        public Task<IEnumerable<Status>> GetRequisitionStates();
        public Task<Status> GetOne(int id);
    }
}
