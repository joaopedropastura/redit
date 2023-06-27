using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class Like
{
    public int Id { get; set; }

    public string? IdUser { get; set; }

    public int? IdPost { get; set; }

    public virtual Post? IdPostNavigation { get; set; }

    public virtual Usertable? IdUserNavigation { get; set; }
}
