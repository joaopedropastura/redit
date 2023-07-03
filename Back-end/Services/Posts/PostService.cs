using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Back_end.Model;

public class PostService : IPostService
{
    private RedeSocialContext entity;


    public PostService(RedeSocialContext service) => this.entity = service;

    public async Task Add(Post post)
    {
        entity.Posts.Add(post);
        await entity.SaveChangesAsync();
    }
    public async Task<List<Post>> Filter(Expression<Func<Post, bool>> exp)
    {
        var query = entity.Posts.Where(exp);
        return await query.ToListAsync();
    }

}