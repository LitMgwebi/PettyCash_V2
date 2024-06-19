namespace PettyCashPrototype.Services.OfficeService
{
    public interface IOffice
    {
        public Task<IEnumerable<Office>> GetAll();
        public Task<Office> GetOne(int id);
        public void Create(Office office);
        public void Edit(Office office);
        public void SoftDelete(Office office);
    }
}
