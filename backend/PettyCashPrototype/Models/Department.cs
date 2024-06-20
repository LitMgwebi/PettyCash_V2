using System;
using System.Collections.Generic;

namespace PettyCashPrototype.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
