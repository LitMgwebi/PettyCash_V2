namespace PettyCashPrototype.Services.DocumentService.GetOneDocument
{
    public class GetDocumentHandler
    {
        private IGetDocument state = null!;

        public void setState(IGetDocument state) => this.state = state;

        public async Task<Document> GetDocument()
        {
            Document document = await state.GetOneDocument();
            return document;
        }
    }
}
