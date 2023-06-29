
using System.Linq.Expressions;
using Back_end.Model;

public interface ICommunityService
{
    Task<List<Comunity>> Filter(Expression<Func<Comunity, bool>> exp);
    Task Remove(Comunity comunity);
    Task Add(Comunity comunity);

}