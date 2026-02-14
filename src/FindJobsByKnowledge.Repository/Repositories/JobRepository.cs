using FindJobsByKnowledge.Domain.Entities;
using FindJobsByKnowledge.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FindJobsByKnowledge.Repository.Repositories;

public class JobRepository : IJobRepository
{
    private readonly ApplicationDbContext _context;

    public JobRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Job>> GetAllAsync()
    {
        return await _context.Jobs
            .Where(j => j.IsActive)
            .OrderByDescending(j => j.PostedDate)
            .ToListAsync();
    }

    public async Task<Job?> GetByIdAsync(Guid id)
    {
        return await _context.Jobs.FindAsync(id);
    }

    public async Task<IEnumerable<Job>> GetByKnowledgeAsync(string knowledge)
    {
        return await _context.Jobs
            .Where(j => j.IsActive && j.RequiredKnowledge.Any(k => k.Contains(knowledge)))
            .OrderByDescending(j => j.PostedDate)
            .ToListAsync();
    }

    public async Task<Job> CreateAsync(Job job)
    {
        job.Id = Guid.NewGuid();
        job.CreatedAt = DateTime.UtcNow;
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();
        return job;
    }

    public async Task<Job> UpdateAsync(Job job)
    {
        job.UpdatedAt = DateTime.UtcNow;
        _context.Entry(job).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return job;
    }

    public async Task DeleteAsync(Guid id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job != null)
        {
            job.IsActive = false;
            job.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
