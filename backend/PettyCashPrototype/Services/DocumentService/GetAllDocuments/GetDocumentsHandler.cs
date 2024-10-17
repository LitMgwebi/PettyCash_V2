namespace PettyCashPrototype.Services.DocumentService.GetAllDocuments
{
    public class GetDocumentsHandler
    {
        private IDocumentsState state = null!;

        public void setState(IDocumentsState state) => this.state = state;

        public async Task<IEnumerable<Document>> request()
        {
            IEnumerable<Document> documents = await state.GetDocuments();
            return documents;
        }
    }
}
