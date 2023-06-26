using System.Linq.Expressions;

namespace Back_end.Model;

public class UserService : IUserService
{
    private RedeSocialContext entity;

    public UserService(RedeSocialContext service) => this.entity = service;
    public void Add(UserTable user)
    {
        entity.UserTables.Add(user);
        entity.SaveChanges();
    }
}