using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Back_end.Model;

public class PostService : IPostService
{
    private RedeSocialContext entity;


    public PostService(RedeSocialContext service) => this.entity = service;

    public Post public Task Add(Post post)
    {
        throw new NotImplementedException();
    }
}