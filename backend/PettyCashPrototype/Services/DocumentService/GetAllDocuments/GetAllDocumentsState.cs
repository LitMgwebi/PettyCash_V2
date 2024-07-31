namespace PettyCashPrototype.Services.DocumentService.GetAllDocuments
{
    public class GetAllDocumentsState : IDocumentState
    {
        private PettyCashPrototypeContext _db;
        public GetAllDocumentsState(PettyCashPrototypeContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            IEnumerable<Document> documents = await _db.Documents
               .OfType<Motivation>()
               .Where(x => x.IsActive == true)
               .AsNoTracking()
               .ToListAsync();

            if (documents == null)
                throw new Exception("System could not find any motivations.");

            return documents;
        }
    }
}
