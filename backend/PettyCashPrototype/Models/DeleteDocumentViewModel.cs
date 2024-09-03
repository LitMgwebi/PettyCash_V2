namespace PettyCashPrototype.Models
{
    public class DeleteDocumentViewModel
    {
        //public int documentId {  get; set; }
        public Document document { get; set; } = null!;
        public string command { get; set; } = null!;
    }
}
