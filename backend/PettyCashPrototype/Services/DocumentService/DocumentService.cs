using PettyCashPrototype.Services.DocumentService.GetAllDocuments;

namespace PettyCashPrototype.Services.DocumentService
{
    public class DocumentService : IDocument
    {
        private PettyCashPrototypeContext _db;
        public DocumentService(PettyCashPrototypeContext db) { 
            _db = db;
        }

        public async Task<IEnumerable<Document>> GetAll(int requisitionId)
        {
            try
            {
                GetDocumentsHandler documentsHandler = new GetDocumentsHandler();
                IEnumerable<Document> documents = new List<Document>();

                if(requisitionId == 0)
                {
                    documentsHandler.setState(new GetAllDocumentsState(_db));
                    documents = await documentsHandler.request();
                } 
                else if (requisitionId > 0)
                {
                    documentsHandler.setState(new GetAllByRequisitionState(_db, requisitionId));
                    documents = await documentsHandler.request();
                }
                return documents;
            }
            catch { throw; }
        }

        public async Task<Document> GetOne(int id)
        {
            try
            {
                //Motivation motivation = await _db.Motivations
                //    .Where(a => a.IsActive == true)
                //    .Include(d => d.Requisition)
                //    .AsNoTracking()
                //    .FirstOrDefaultAsync(x => x.FileId == id);
                Motivation motivation = new Motivation();

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
                    motivation.FileName = $"{name}-{motivation.DateUploaded.ToString("yyyyMMddTHHmmss")}-Petty Cash-{requisitionId}.{fileExtension}";
                    motivation.RequisitionId = requisitionId;

                    string filePath = Path.Combine("Resources", $"{name}-{motivation.DateUploaded.ToString("yyyyMMddTHHmmss")}-Petty Cash-{requisitionId}.{fileExtension}");
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    _db.Documents.Add(motivation);

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

        public void Edit(Document document)
        {
            try
            {
                _db.Documents.Update(document);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not edit ${document.FileName}.{document.FileExtension}.");
            }
            catch { throw; }
        }

        public void SoftDelete(Document document)
        {
            try
            {
                document.IsActive = false;
                _db.Documents.Update(document);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not delete ${document.FileName}.{document.FileExtension}.");
            }
            catch { throw; }
        }
    }
}