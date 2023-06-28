using System.Linq.Expressions;
using Back_end.Model;
public interface IUserService
{
    Task<bool> Exist(Expression<Func<Usertable, bool>> exp);
    Task Add(Usertable user);
    Task<Usertable> FindByEmail(string email);
    Task<List<Usertable>> Filter(Expression<Func<Usertable, bool>> exp);
}
