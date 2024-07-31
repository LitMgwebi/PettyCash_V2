namespace PettyCashPrototype.Services.DocumentService
{
    public interface IDocument
    {
        public Task<IEnumerable<Document>> GetAll(int requisitionId);
        //public Task<IList<Motivation>> GetAllByRequisition(int requisitionId);
        public Task<Document> GetOne(int id);
        public Task<string> Upload(IFormFile file, int id, string name);
        public void Edit(Document document);
        public void SoftDelete(Document document);
    }
}
