using System.Linq.Expressions;

namespace Back_end.Model;

public class NewUser : INewUser
{
    private RedeSocialContext entity;

    public NewUser(RedeSocialContext service) => this.entity = service;
    public void Add(UserTable user)
    {
        entity.UserTables.Add(user);
        entity.SaveChanges();
    }
}