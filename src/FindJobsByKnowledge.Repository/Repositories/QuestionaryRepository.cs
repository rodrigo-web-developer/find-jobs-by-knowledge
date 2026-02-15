using FindJobsByKnowledge.Domain.Entities;
using FindJobsByKnowledge.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FindJobsByKnowledge.Repository.Repositories;

public class QuestionaryRepository : IQuestionaryRepository
{
    private readonly ApplicationDbContext _context;

    public QuestionaryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Questionary>> GetAllAsync()
    {
        return await _context.Questionaries
            .Include(q => q.Items)
                .ThenInclude(i => i.Question)
            .Include(q => q.Results)
            .OrderByDescending(q => q.CreatedAt)
            .ToListAsync();
    }

    public async Task<Questionary?> GetByIdAsync(Guid id)
    {
        return await _context.Questionaries
            .Include(q => q.Items)
                .ThenInclude(i => i.Question)
            .Include(q => q.Results)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<Questionary> CreateAsync(Questionary questionary)
    {
        questionary.Id = Guid.NewGuid();
        questionary.CreatedAt = DateTime.UtcNow;

        foreach (var item in questionary.Items)
        {
            item.Id = Guid.NewGuid();
            item.QuestionaryId = questionary.Id;
        }

        _context.Questionaries.Add(questionary);
        await _context.SaveChangesAsync();
        return questionary;
    }

    public async Task<Questionary> UpdateAsync(Questionary questionary)
    {
        _context.Entry(questionary).State = EntityState.Modified;

        foreach (var item in questionary.Items)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        await _context.SaveChangesAsync();
        return questionary;
    }
}
