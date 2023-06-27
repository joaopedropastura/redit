using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class Permission
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<ResponsibilityPermission> ResponsibilityPermissions { get; set; } = new List<ResponsibilityPermission>();
}
