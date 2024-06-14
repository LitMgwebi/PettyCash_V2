namespace PettyCashPrototype.Services.PurposeService
{
    public interface IPurpose
    {
        public Task<IEnumerable<Purpose>> GetAll();
        public Task<Purpose> GetOne(int id);
        public Task<int> Create(Purpose purpose);
        public Task<int> Edit(Purpose purpose);
        public Task<int> Delete(int id);
    }
}
