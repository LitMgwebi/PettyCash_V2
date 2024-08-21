using PettyCashPrototype.Services.DocumentService.GetAllDocuments;
using PettyCashPrototype.Services.DocumentService.GetOneDocument;
using PettyCashPrototype.Services.DocumentService.UploadDocument;

namespace PettyCashPrototype.Services.DocumentService
{
    public class DocumentService : IDocument
    {
        private PettyCashPrototypeContext _db;
        public DocumentService(PettyCashPrototypeContext db) { 
            _db = db;
        }

        public async Task<IEnumerable<Document>> GetAll(string command, int requisitionId)
        {
            try
            {
                GetDocumentsHandler documentsHandler = new GetDocumentsHandler();
                IEnumerable<Document> documents = new List<Document>();

                if (command == "motivation")
                {
                    if (requisitionId == 0)
                    {
                        documentsHandler.setState(new GetMotivationsState(_db));
                        documents = await documentsHandler.request();
                    }
                    else if (requisitionId > 0)
                    {
                        documentsHandler.setState(new GetMotivationsByRequisitionState(_db, requisitionId));
                        documents = await documentsHandler.request();
                    }
                } else if (command == "receipt")
                {
                    if (requisitionId == 0)
                    {
                        documentsHandler.setState(new GetReceiptsState(_db));
                        documents = await documentsHandler.request();
                    }
                    else if (requisitionId > 0)
                    {
                        documentsHandler.setState(new GetReceiptsByRequisitionState(_db, requisitionId));
                        documents = await documentsHandler.request();
                    }
                }

                return documents;
            }
            catch { throw; }
        }

        public async Task<Document> GetOne(string command, int documentId)
        {
            try
            {
                GetDocumentHandler documentHandler = new GetDocumentHandler();
                Document document = new Document();
                if (command == "motivations")
                {
                    documentHandler.setState(new GetOneMotivationState(_db, documentId));
                    document = await documentHandler.GetDocument();
                }
                else if (command == "receipts")
                {
                    documentHandler.setState(new GetOneReceiptState(_db, documentId));
                    document = await documentHandler.GetDocument();
                }

                return document;
            }
            catch { throw; }
        }

        public async Task<string> Upload(string command, IFormFile file, int requisitionId, string name)
        {
            try
            {                
                //TODO upload multiple files at the same time
                UploadDocumentHandler uploadDocumentHandler = new UploadDocumentHandler();

                if (file == null) throw new Exception("No file was found.");

                string message = string.Empty;
                string[] allowedFileTypes = { "pdf" };
                string fileExtension = Path.GetExtension(file.FileName).Substring(1);
                
                if (!allowedFileTypes.Contains(fileExtension))
                {
                    throw new Exception($"File format {Path.GetExtension(file.FileName)} is invalid for this operation. Please select a PDF file.");
                }
                if (file.Length > 0)
                {
                    if(command == typesOfDocument.Motivation)
                    {
                        uploadDocumentHandler.setState(new UploadMotivationState(_db, file, name, requisitionId, fileExtension));
                        message = await uploadDocumentHandler.request();
                    } 
                    else if (command == typesOfDocument.Receipt)
                    {
                        uploadDocumentHandler.setState(new UploadReceiptState(_db, file, name, requisitionId, fileExtension));
                        message = await uploadDocumentHandler.request();
                    }
                    else 
                        throw new Exception("Could not recognize command given for uploading document.");
                }
                else
                {
                    throw new FileLoadException("Cannot load file");
                }

                return message;
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