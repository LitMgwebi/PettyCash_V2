namespace PettyCashPrototype.Services.PurposeService
{
    public interface IPurpose
    {
        public Task<IEnumerable<Purpose>> GetAll();
        public Task<Purpose> GetOne(int id);
        public void Create(Purpose purpose);
        public void Edit(Purpose purpose);
        public void SoftDelete(Purpose purpose);
    }
}
