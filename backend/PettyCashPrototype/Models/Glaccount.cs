namespace PettyCashPrototype.Models;

public partial class Glaccount
{
    public int GlaccountId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int MainAccountId { get; set; }

    public int SubAccountId { get; set; }

    public int PurposeId { get; set; }

    public int DivisionId { get; set; }

    public int OfficeId { get; set; }

    public bool IsActive { get; set; } = true;
    
    public bool NeedsMotivation { get; set; } = true;

    public virtual MainAccount? MainAccount { get; set; }

    public virtual Purpose? Purpose { get; set; }

    public virtual Division? Division { get; set; }

    public virtual Office? Office { get; set; }

    [JsonIgnore]
    public virtual ICollection<Requisition> Requisitions { get; set; } = new List<Requisition>();

    public virtual SubAccount? SubAccount { get; set; }
}
