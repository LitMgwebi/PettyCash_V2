namespace PettyCashPrototype.Services.DocumentService.GetOneDocument
{
    public class GetMotivationState: IGetDocument
    {
        private PettyCashPrototypeContext db;
        private readonly int documentId;

        public GetMotivationState(PettyCashPrototypeContext db, int documentId)
        {
            this.db = db;
            this.documentId = documentId;
        }

        public async Task<Document> GetOneDocument()
        {
            Document document = await db.Documents
                .OfType<Motivation>()
                .Where(a => a.IsActive == true)
                .Include(d => d.Requisition)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DocumentId == documentId);


            if (document == null) throw new Exception("System could not retrieve the motivation.");

            return document!;
        }
    }
}
