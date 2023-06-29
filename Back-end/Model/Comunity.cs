using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class Comunity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Creator { get; set; }

    public string? Description { get; set; }

    public virtual Usertable? CreatorNavigation { get; set; }

    public virtual ICollection<HasResponsibility> HasResponsibilities { get; set; } = new List<HasResponsibility>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
