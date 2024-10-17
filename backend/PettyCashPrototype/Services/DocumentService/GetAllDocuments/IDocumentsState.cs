namespace PettyCashPrototype.Services.DocumentService.GetAllDocuments
{
    public interface IDocumentsState
    {
        Task<IEnumerable<Document>> GetDocuments();
    }
}
