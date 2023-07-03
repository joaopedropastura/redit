using System.Linq.Expressions;
using Back_end.Model;

public interface IPostService
{
    Task Add(Post post);
    Task<List<Post>> Filter(Expression<Func<Post, bool>> exp);

}