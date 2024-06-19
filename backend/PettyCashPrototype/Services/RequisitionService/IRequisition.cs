namespace PettyCashPrototype.Services.RequisitionService
{
    public interface IRequisition
    {
        public Task<IEnumerable<Requisition>> GetAll();
        public Task<Requisition> GetOne(int id);
        public void Create(Requisition requisition);
        public void Edit(Requisition requisition);
        public void SoftDelete(Requisition requisition);
    }
}
