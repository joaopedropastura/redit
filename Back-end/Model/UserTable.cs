using System;
using System.Collections.Generic;

namespace Back_end.Model;

public partial class UserTable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime? BornDate { get; set; }

    public DateTime AssignDate { get; set; }

    public string Password { get; set; } = null!;
}
