using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class Usertable
{
    public string Cpf { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string? Salt { get; set; }

    public string Password { get; set; } = null!;

    public DateTime? Borndate { get; set; }

    public DateTime Assigndate { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Comunity> Comunities { get; set; } = new List<Comunity>();

    public virtual ICollection<HasResponsibility> HasResponsibilities { get; set; } = new List<HasResponsibility>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
