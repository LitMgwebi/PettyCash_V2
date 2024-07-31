namespace PettyCashPrototype.Services.DocumentService.UploadDocument
{
    public class UploadReceiptState : IUploadDocument
    {
        private PettyCashPrototypeContext _db;
        private IFormFile file;
        private readonly string name;
        private readonly int requisitionId;
        private readonly string fileExtension;

        public UploadReceiptState(PettyCashPrototypeContext db, IFormFile file, string name, int requisitionId, string fileExtension)
        {
            this.file = file;
            this.name = name;
            this.requisitionId = requisitionId;
            this.fileExtension = fileExtension;
            _db = db;
        }

        public async Task<string> UploadDocument()
        {
            Document document = new Receipt();

            document.FileExtension = fileExtension;
            document.DateUploaded = DateTime.Now;
            document.FileName = $"{name}-{document.DateUploaded.ToString("yyyyMMddTHHmmss")}-Petty Cash Receipt-{requisitionId}.{fileExtension}";
            document.RequisitionId = requisitionId;

            string filePath = Path.Combine("Resources", $"{name}-{document.DateUploaded.ToString("yyyyMMddTHHmmss")}-Petty Cash Receipt-{requisitionId}.{fileExtension}");
            
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            _db.Documents.Add(document);

            int result = _db.SaveChanges();
            if (result == 0) throw new DbUpdateException("System was unable to add the new receipt.");

            return "The recipt has been uploaded successfully.";
        }
    }
}
