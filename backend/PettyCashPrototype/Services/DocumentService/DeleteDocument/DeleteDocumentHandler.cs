namespace PettyCashPrototype.Services.DocumentService.DeleteDocument
{
    public class DeleteDocumentHandler
    {
        private IDeleteDocument state = null!;

        public void setState(IDeleteDocument state) { this.state = state; }

        public async Task<string> request(PettyCashContext db, IRequisition _requisition, Document document)
        {
            string message = await state.DeleteDocument(db, _requisition, document);
            return message;
        }
    }
}
