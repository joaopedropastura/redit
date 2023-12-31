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

    public async Task Update(Comunity community)
    {
        entity.Comunities.Update(community);
        await entity.SaveChangesAsync();
    }

    public async Task<bool> Exist(Expression<Func<Comunity, bool>> exp)
    {
        return await entity.Comunities.AnyAsync(exp);
    }

    public async Task<List<HasResponsibility>> FilterIsMember(Expression<Func<HasResponsibility, bool>> exp)
    {
        var query = entity.HasResponsibilities.Where(exp);
        return await query.ToListAsync();
    }

    public async Task AddMember(HasResponsibility hasResponsibility)
    {
        entity.HasResponsibilities.Add(hasResponsibility);
        await entity.SaveChangesAsync();
    }

    public async Task AddResponsibility(Responsibility responsibility)
    {
        entity.Responsibilities.Add(responsibility);
        await entity.SaveChangesAsync();
    }

    public async Task<int> CountMembers(HasResponsibility hasResponsibility)
    {
        return await entity.HasResponsibilities.CountAsync();
    }
}