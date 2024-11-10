namespace PettyCashPrototype.Services.DocumentService.GetAllDocuments
{
    public class GetMotivationsState : IDocumentsState
    {
        private PettyCashContext _db;
        public GetMotivationsState(PettyCashContext db)
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
