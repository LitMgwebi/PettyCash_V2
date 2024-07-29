using System.ComponentModel.DataAnnotations.Schema;

namespace PettyCashPrototype.Models
{
    [Table("Motivation")]
    public class Motivation
    {
        public int MotivationId { get; set; }
        public string FileName { get; set; } = null!;
        public string FileExtension { get; set; } = null!;
        public DateTime DateUploaded { get; set; }
        public int RequisitionId { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(RequisitionId))]
        public virtual Requisition? Requisition { get; set; }
    }
}
