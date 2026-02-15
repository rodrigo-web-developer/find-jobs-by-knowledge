using FindJobsByKnowledge.Domain.Entities;

namespace FindJobsByKnowledge.Repository.Repositories;

public interface IQuestionaryRepository
{
    Task<IEnumerable<Questionary>> GetAllAsync();
    Task<Questionary?> GetByIdAsync(Guid id);
    Task<Questionary> CreateAsync(Questionary questionary);
    Task<Questionary> UpdateAsync(Questionary questionary);
}
