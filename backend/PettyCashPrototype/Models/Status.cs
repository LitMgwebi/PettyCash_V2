namespace PettyCashPrototype.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string? Option { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsRecommended { get; set; }

    public bool IsApproved { get; set; }

    [JsonIgnore]
    public virtual ICollection<Requisition> FinanceApprovals { get; set; } = new List<Requisition>();

    [JsonIgnore]
    public virtual ICollection<Requisition> ManagerRecommendations { get; set; } = new List<Requisition>();
    
    //[JsonIgnore]
    //public virtual ICollection<Requisition> Statuses { get; set; } = new List<Requisition>();
}
