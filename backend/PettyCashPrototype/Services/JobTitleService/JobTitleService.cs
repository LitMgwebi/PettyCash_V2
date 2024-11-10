namespace PettyCashPrototype.Services.JobTitleService
{
    public class JobTitleService: IJobTitle
    {
        private PettyCashContext _db;
        public JobTitleService(PettyCashContext db) { _db = db; }

        public async Task<IEnumerable<JobTitle>> GetAll()
        {
            try
            {
                IEnumerable<JobTitle> jobTitles = await _db.JobTitles
                    .Where(x => x.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (jobTitles == null)
                    throw new Exception("System could not find any job titles");

                return jobTitles;
            }
            catch { throw; }
        }

        public async Task<JobTitle> GetOne(int id)
        {
            try
            {
                JobTitle jobTitle = await _db.JobTitles
                    .Where(x => x.IsActive == true)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.JobTitleId == id);

                if(jobTitle == null)
                    throw new Exception("System could not find any job titles");

                return jobTitle;
            } catch { throw; }
        } 
    }
}
