using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PettyCashPrototype.Seeding;

namespace PettyCashPrototype.Models;

public partial class Division
{
    public int DivisionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int DepartmentId { get; set; }

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(DepartmentId))]
    public Department? Department { get; set; }

    [JsonIgnore]
    public virtual ICollection<Glaccount> Glaccounts { get; set; } = new List<Glaccount>();

    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();

}
