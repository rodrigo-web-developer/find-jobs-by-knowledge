using FindJobsByKnowledge.Domain.Entities;
using FindJobsByKnowledge.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FindJobsByKnowledge.Repository.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationDbContext _context;

    public QuestionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        return await _context.Questions
            .Where(q => q.IsActive)
            .OrderBy(q => q.Tag)
            .ThenBy(q => q.Level)
            .ToListAsync();
    }

    public async Task<Question?> GetByIdAsync(Guid id)
    {
        return await _context.Questions.FindAsync(id);
    }

    public async Task<IEnumerable<Question>> GetByTagAsync(string tag)
    {
        var lowerTag = tag.ToLower();
        return await _context.Questions
            .Where(q => q.IsActive && q.Tag.ToLower() == lowerTag)
            .OrderBy(q => q.Level)
            .ToListAsync();
    }

    public async Task<IEnumerable<Question>> GetByTagAndLevelAsync(string tag, int level)
    {
        var lowerTag = tag.ToLower();
        return await _context.Questions
            .Where(q => q.IsActive && q.Tag.ToLower() == lowerTag && q.Level == level)
            .ToListAsync();
    }

    public async Task<Question> CreateAsync(Question question)
    {
        question.Id = Guid.NewGuid();
        question.CreatedAt = DateTime.UtcNow;
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return question;
    }

    public async Task<Question> UpdateAsync(Question question)
    {
        question.UpdatedAt = DateTime.UtcNow;
        _context.Entry(question).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return question;
    }

    public async Task DeleteAsync(Guid id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question != null)
        {
            question.IsActive = false;
            question.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
