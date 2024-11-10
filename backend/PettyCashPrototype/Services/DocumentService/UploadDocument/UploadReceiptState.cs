namespace PettyCashPrototype.Services.DocumentService.UploadDocument
{
    public class UploadReceiptState : IUploadDocument
    {
        private PettyCashContext _db;
        private IFormFile file;
        private IRequisition _requisition;
        private readonly string name;
        private readonly int requisitionId;
        private readonly string fileExtension;

        public UploadReceiptState(PettyCashContext db, IRequisition requisition, IFormFile file, string name, int requisitionId, string fileExtension)
        {
            this.file = file;
            this.name = name;
            this.requisitionId = requisitionId;
            this.fileExtension = fileExtension;
            _requisition = requisition;
            _db = db;
        }

        public async Task<string> UploadDocument()
        {
            Requisition requisition = await _requisition.GetOne(requisitionId);
            if (requisition.StateId == 7)
            {
                if (file.Length < 5242880)
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

                    return "The recipt has been uploaded successfully";
                }
                else
                    throw new Exception("The receipt you uploaded is too large, please constrict size to 5 MB");
            } else
                throw new Exception("Cannot upload receipt whilst not in Issued state");
        }
    }
}
