using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Model;

public class CommunityService : ICommunityService
{

    private RedeSocialContext entity;

    public CommunityService(RedeSocialContext service) => this.entity = service;
    public async Task<List<Comunity>> Filter(Expression<Func<Comunity, bool>> exp)
    {
        var query = entity.Comunities.Where(exp);
        return await query.ToListAsync();
    }
    public async Task Add(Comunity community)
    {
        entity.Comunities.Add(community);
        await entity.SaveChangesAsync();
    }

    public async Task Remove(Comunity community)
    {
        entity.Comunities.Remove(community);
        await entity.SaveChangesAsync();
    }

    
}