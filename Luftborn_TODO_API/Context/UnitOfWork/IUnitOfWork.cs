using Luftborn_TODO_API.Repositories.TaskRepository;

namespace Luftborn_TODO_API.Context.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
	ITaskRepository Tasks { get; }
	Task<int> SaveChangesAsync();
}
