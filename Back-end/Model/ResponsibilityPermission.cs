using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class ResponsibilityPermission
{
    public int Id { get; set; }

    public int? IdResponsibility { get; set; }

    public int? IdPermission { get; set; }

    public virtual Permission? IdPermissionNavigation { get; set; }

    public virtual Responsibility? IdResponsibilityNavigation { get; set; }
}
