namespace PettyCashPrototype.Services.MotivationService
{
    public interface IMotivation
    {
        public Task<IEnumerable<Motivation>> GetAll(int requisitionId);
        //public Task<IList<Motivation>> GetAllByRequisition(int requisitionId);
        public Task<Motivation> GetOne(int id);
        public Task<string> Upload(IFormFile file, int id, string name);
        public void Edit(Motivation division);
        public void SoftDelete(Motivation division);
    }
}
