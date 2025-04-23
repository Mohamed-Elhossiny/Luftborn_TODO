using Luftborn_TODO_API.Models;

namespace Luftborn_TODO_API.Repositories.TaskRepository;

public interface ITaskRepository
{
	Task<IEnumerable<Tasks>> GetAllAsync();
	Task<Tasks?> GetByIdAsync(int id);
	Task<Tasks> AddAsync(Tasks task);
	Task<Tasks?> UpdateAsync(Tasks task);
	Task<bool> DeleteAsync(int id);
	Task<bool> ExistsAsync(int id);
}
