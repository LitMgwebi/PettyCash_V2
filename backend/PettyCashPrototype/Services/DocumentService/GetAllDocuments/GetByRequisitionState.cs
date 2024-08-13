namespace PettyCashPrototype.Services.DocumentService.GetDocuments
{
    public class GetByRequisitionState : IDocumentState
    {
        private PettyCashPrototypeContext db;
        private readonly int requisitionId;
        public GetByRequisitionState(PettyCashPrototypeContext db, int requisitionId)
        {
            this.db = db;
            this.requisitionId = requisitionId;
        }
        public async Task<IEnumerable<Document>> GetDocuments()
        {
            IEnumerable<Document> documents = await db.Documents
                .OfType<Motivation>()
                .Where(x => x.IsActive == true)
                .Where(r => r.RequisitionId == requisitionId)
                .AsNoTracking()
                .ToListAsync();

            if (documents == null)
                throw new Exception("System could not find the motivations for this requisition.");

            return documents;
        }
    }
}
