namespace PettyCashPrototype.Models
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string Description { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
