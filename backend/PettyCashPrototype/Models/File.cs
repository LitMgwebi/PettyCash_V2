namespace PettyCashPrototype.Models
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; } = null!;
        public string FileExtension { get; set; } = null!;
        public DateTime DateUploaded { get; set; }
    }
}
