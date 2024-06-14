namespace PettyCashPrototype.Models;

public partial class MainAccount
{
    public int MainAccountId { get; set; }

    public int AccountNumber { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    [JsonIgnore]
    public virtual ICollection<Glaccount> Glaccounts { get; set; } = new List<Glaccount>();
}
