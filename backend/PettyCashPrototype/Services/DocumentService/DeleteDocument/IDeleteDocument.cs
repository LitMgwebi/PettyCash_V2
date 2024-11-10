namespace PettyCashPrototype.Services.DocumentService.DeleteDocument
{
    public interface IDeleteDocument
    {
        Task<string> DeleteDocument(PettyCashContext db, IRequisition _requisition, Document document);
    }
}
