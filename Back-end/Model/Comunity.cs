using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class Comunity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<HasResponsibility> HasResponsibilities { get; set; } = new List<HasResponsibility>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
