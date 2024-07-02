using System.ComponentModel.DataAnnotations.Schema;

namespace PettyCashPrototype.Models
{
    [Table("JobTitle")]
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; } = true;


        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
