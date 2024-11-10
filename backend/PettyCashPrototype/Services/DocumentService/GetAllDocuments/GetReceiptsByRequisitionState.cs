namespace PettyCashPrototype.Services.DocumentService.GetAllDocuments
{
    public class GetReceiptsByRequisitionState : IDocumentsState
    {
        private PettyCashContext db;
        private readonly int requisitionId;
        public GetReceiptsByRequisitionState(PettyCashContext db, int requisitionId)
        {
            this.db = db;
            this.requisitionId = requisitionId;
        }
        public async Task<IEnumerable<Document>> GetDocuments()
        {
            IEnumerable<Document> documents = await db.Documents
                .OfType<Receipt>()
                .Where(x => x.IsActive == true)
                .Where(r => r.RequisitionId == requisitionId)
                .AsNoTracking()
                .ToListAsync();

            if (documents == null)
                throw new Exception("System could not find the receipts for this requisition.");

            return documents;
        }
    }
}
