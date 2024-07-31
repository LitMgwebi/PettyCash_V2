namespace PettyCashPrototype.Services.DocumentService.GetAllDocuments
{
    public class GetDocumentsHandler
    {
        private IDocumentState state = null!;

        public void setState(IDocumentState state) => this.state = state;

        public async Task<IEnumerable<Document>> request()
        {
            IEnumerable<Document> motivations = await state.GetDocuments();
            return motivations;
        }
    }
}
