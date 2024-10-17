namespace PettyCashPrototype.Services.DivisionService
{
    public interface IDivision
    {
        public Task<IEnumerable<Division>> GetAll();
        public Task<Division> GetOne(int id);
        public void Create(Division division);
        public void Edit(Division division);
        public void SoftDelete(Division division);
    }
}
