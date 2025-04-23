using Luftborn_TODO_API.Repositories.TaskRepository;
using System;

namespace Luftborn_TODO_API.Context.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private readonly TODOContext _context;
	public ITaskRepository Tasks { get; }

	public UnitOfWork(TODOContext context)
	{
		_context = context;
		Tasks = new TaskRepository(context);
	}

	public async Task<int> SaveChangesAsync()
	{
		return await _context.SaveChangesAsync();
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
