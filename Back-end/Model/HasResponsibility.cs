using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class HasResponsibility
{
    public int Id { get; set; }

    public int? IdComunity { get; set; }

    public string? IdUser { get; set; }

    public int? IdResponsibility { get; set; }

    public virtual Comunity? IdComunityNavigation { get; set; }

    public virtual Responsibility? IdResponsibilityNavigation { get; set; }

    public virtual Usertable? IdUserNavigation { get; set; }
}
