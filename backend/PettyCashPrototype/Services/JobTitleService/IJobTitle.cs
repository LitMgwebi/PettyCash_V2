namespace PettyCashPrototype.Services.JobTitleService
{
    public interface IJobTitle
    {
        public Task<IEnumerable<JobTitle>> GetAll();
        public Task<JobTitle> GetOne(int id);
    }
}
