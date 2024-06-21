using System;
using System.Collections.Generic;

namespace PettyCashPrototype.Models;

public partial class Glaccount
{
    public int GlaccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int MainAccountId { get; set; }

    public int SubAccountId { get; set; }

    public int PurposeId { get; set; }

    public int DepartmentId { get; set; }

    public int OfficeId { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual MainAccount MainAccount { get; set; } = null!;

    public virtual Purpose Purpose { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Requisition> Requisitions { get; set; } = new List<Requisition>();

    public virtual SubAccount SubAccount { get; set; } = null!;
}
