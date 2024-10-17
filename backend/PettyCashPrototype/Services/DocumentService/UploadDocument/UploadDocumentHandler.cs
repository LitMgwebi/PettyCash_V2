namespace PettyCashPrototype.Services.DocumentService.UploadDocument
{
    public class UploadDocumentHandler
    {
        private IUploadDocument state = null!;

        public void setState(IUploadDocument state) { this.state = state; }

        public async Task<string> request()
        {
            string message = await state.UploadDocument();
            return message;
        }
    }
}
