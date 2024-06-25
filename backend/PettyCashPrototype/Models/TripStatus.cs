namespace PettyCashPrototype.Models;

public partial class TripStatus
{
    public int TripStatusId { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    [JsonIgnore]
    public virtual ICollection<Requisition> FinanceApprovals { get; set; } = new List<Requisition>();

    [JsonIgnore]
    public virtual ICollection<Requisition> ManagerApprovals { get; set; } = new List<Requisition>();
    
    [JsonIgnore]
    public virtual ICollection<Requisition> Statuses { get; set; } = new List<Requisition>();
}
