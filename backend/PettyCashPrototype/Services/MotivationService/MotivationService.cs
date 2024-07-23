using System.Threading;

namespace PettyCashPrototype.Services.MotivationService
{
    public class MotivationService : IMotivation
    {
        private PettyCashPrototypeContext _db;
        public MotivationService(PettyCashPrototypeContext db) { _db = db; }

        public async Task<IEnumerable<Motivation>> GetAll()
        {
            try
            {
                IEnumerable<Motivation> motivations = await _db.Motivations
                    .Where(x => x.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (motivations == null)
                    throw new Exception("System could not find any motivations.");

                return motivations;
            }
            catch { throw; }
        }

        public async Task<Motivation> GetOne(int id)
        {
            try
            {
                Motivation motivation = await _db.Motivations
                    .Where(a => a.IsActive == true)
                    .Include(d => d.Requisition)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.MotivationId == id);

                if (motivation == null) throw new Exception("System could not retrieve the Motivation.");

                return motivation;
            }
            catch { throw; }
        }

        public async Task<string> Upload(IFormFile file, int requisitionId, string name)
        {
            try
            {
                Motivation motivation = new Motivation();
                if (file == null) throw new Exception("No file was found.");

                var allowedFileTypes = new[] { "pdf" };

                if (file.Length > 0)
                {
                    var fileExtension = Path.GetExtension(file.FileName).Substring(1);
                    if (!allowedFileTypes.Contains(fileExtension))
                    {
                        throw new Exception($"File format {Path.GetExtension(file.FileName)} is invalid for this operation.");
                    }
                    else
                    {
                        motivation.FileExtension = fileExtension;
                    }
                    motivation.DateUploaded = DateTime.Now;
                    motivation.FileName = $"{name}-{motivation.DateUploaded.ToString("yyyyMMddTHHmmss")}-Petty Cash.{fileExtension}";
                    motivation.RequisitionId = requisitionId;

                    string filePath = Path.Combine("Resources", $"{name}-{motivation.DateUploaded.ToString("yyyyMMddTHHmmss")}-Petty Cash.{fileExtension}");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    _db.Motivations.Add(motivation);
                    int result = _db.SaveChanges();

                    if (result == 0) throw new DbUpdateException("System was unable to add the new motivation.");
                    return "The motivation has been uploaded successfully.";
                }
                else
                {
                    throw new FileLoadException("Cannot load file");
                }
            }
            catch { throw; }
        }

        public void Edit(Motivation motivation)
        {
            try
            {
                _db.Motivations.Update(motivation);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not edit ${motivation.FileName}.{motivation.FileExtension}.");
            }
            catch { throw; }
        }

        public void SoftDelete(Motivation motivation)
        {
            try
            {
                motivation.IsActive = false;
                _db.Motivations.Update(motivation);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not delete ${motivation.FileName}.{motivation.FileExtension}.");
            }
            catch { throw; }
        }
    }
}