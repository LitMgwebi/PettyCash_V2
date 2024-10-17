﻿namespace PettyCashPrototype.Services.DocumentService.UploadDocument
{
    public class UploadMotivationState : IUploadDocument
    {
        private PettyCashPrototypeContext _db;
        private IFormFile file;
        private IRequisition _requisition;
        private readonly string name;
        private readonly int requisitionId;
        private readonly string fileExtension;

        public UploadMotivationState(PettyCashPrototypeContext db, IRequisition requisition, IFormFile file, string name, int requisitionId, string fileExtension)
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
            if (requisition.ManagerId == null)
            {
                if (file.Length < 5242880)
                {
                    Document document = new Motivation();

                    document.FileExtension = fileExtension;
                    document.DateUploaded = DateTime.Now;
                    document.FileName = $"{name}-{document.DateUploaded.ToString("yyyyMMddTHHmmss")}-Petty Cash Motivation-{requisitionId}.{fileExtension}";
                    document.RequisitionId = requisitionId;

                    string filePath = Path.Combine("Resources", $"{name}-{document.DateUploaded.ToString("yyyyMMddTHHmmss")}-Petty Cash Motivation-{requisitionId}.{fileExtension}");

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    _db.Documents.Add(document);

                    int result = _db.SaveChanges();
                    if (result == 0) throw new DbUpdateException("System was unable to add the new motivation.");

                    return "The motivation has been uploaded successfully";
                }
                else
                    throw new Exception("The motivation you uploaded is too large, please constrict size to 5 MB");
            }
            else
                throw new Exception("A new motivational document cannot be uploaded after line manager has processed requisition.");
        }
    }
}
