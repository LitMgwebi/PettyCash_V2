namespace PettyCashPrototype.Services.DocumentService
{
    public interface IDocument
    {
        public Task<IEnumerable<Document>> GetAll(string command, int requisitionId);
        public Task<Document> GetOne(string command, int documentId);
        public Task<string> Upload(string command, IFormFile file, int id, string name);
        public void Edit(Document document);
        public Task<string> SoftDelete(Document document, string typeOfDocument);
    }
}
