namespace PettyCashPrototype.Services.MotivationService
{
    public interface IMotivation
    {
        public Task<IEnumerable<Motivation>> GetAll();
        public Task<Motivation> GetOne(int id);
        public Task<string> Upload(IFormFile file, int id, string name);
        public void Edit(Motivation division);
        public void SoftDelete(Motivation division);
    }
}
