using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class Responsibility
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ResponsibilityPermission> ResponsibilityPermissions { get; set; } = new List<ResponsibilityPermission>();
}
