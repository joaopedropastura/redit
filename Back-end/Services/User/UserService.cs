using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Model;

public class UserService : IUserService
{
    private RedeSocialContext entity;

    public UserService(RedeSocialContext service) => this.entity = service;

    public async Task<bool> Exist(Expression<Func<Usertable, bool>> exp)
    {
        return await entity.Usertables.AnyAsync(exp);
    }

    public async Task<List<Usertable>> Filter(Expression<Func<Usertable, bool>> exp)
    {
        var query = entity.Usertables.Where(exp);
        return await query.ToListAsync();
    }

    public async Task<Usertable> FindByEmail (string email)
    {

        var query = 
            from user in entity.Usertables
            where user.Email == email
            select user;

        var userList = await query.ToListAsync();
        var log = userList.FirstOrDefault();
        return log;
    }
    public async Task Add(Usertable user)
    {
        entity.Usertables.Add(user);
        await entity.SaveChangesAsync();
    }
}