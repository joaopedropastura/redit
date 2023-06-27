using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class Post
{
    public int Id { get; set; }

    public int? IdComunity { get; set; }

    public string? IdUser { get; set; }

    public string? Title { get; set; }

    public string? PostData { get; set; }

    public DateTime? DatePublish { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Comunity? IdComunityNavigation { get; set; }

    public virtual Usertable? IdUserNavigation { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
