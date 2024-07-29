namespace PettyCashPrototype.Models
{
    public class UploadFile
    {
        public int RequisitionId { get; set; }
        public IFormFile File { get; set; } = null!;
    }
}
