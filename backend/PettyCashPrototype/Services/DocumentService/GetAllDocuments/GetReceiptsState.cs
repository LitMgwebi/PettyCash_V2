namespace PettyCashPrototype.Services.DocumentService.GetAllDocuments
{
    public class GetReceiptsState : IDocumentsState
    {
        private PettyCashContext _db;
        public GetReceiptsState(PettyCashContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            IEnumerable<Document> documents = await _db.Documents
               .OfType<Receipt>()
               .Where(x => x.IsActive == true)
               .AsNoTracking()
               .ToListAsync();

            if (documents == null)
                throw new Exception("System could not find any receipts.");

            return documents;
        }
    }
}
