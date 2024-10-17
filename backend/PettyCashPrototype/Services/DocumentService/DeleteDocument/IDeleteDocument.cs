namespace PettyCashPrototype.Services.DocumentService.DeleteDocument
{
    public interface IDeleteDocument
    {
        Task<string> DeleteDocument(PettyCashPrototypeContext db, IRequisition _requisition, Document document);
    }
}
