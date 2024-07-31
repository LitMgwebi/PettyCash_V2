namespace PettyCashPrototype.Services.DocumentService.GetAllDocuments
{
    public interface IDocumentState
    {
        Task<IEnumerable<Document>> GetDocuments();
    }
}
