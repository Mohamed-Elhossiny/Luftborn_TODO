using Luftborn_TODO_API.Context;
using Luftborn_TODO_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Luftborn_TODO_API.Repositories.TaskRepository;

public class TaskRepository : ITaskRepository
{
	private readonly TODOContext _context;

	public TaskRepository(TODOContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Tasks>> GetAllAsync()
	{
		return await _context.Tasks.ToListAsync();
	}

	public async Task<Tasks?> GetByIdAsync(int id)
	{
		return await _context.Tasks.FindAsync(id);
	}

	public async Task<Tasks> AddAsync(Tasks task)
	{
		_context.Tasks.Add(task);
		await Task.CompletedTask; 
		return task;
	}

	public async Task<Tasks?> UpdateAsync(Tasks task)
	{
		var existing = await _context.Tasks.FindAsync(task.Id);
		if (existing == null) return null;

		existing.Title = task.Title;
		existing.Description = task.Description;
		existing.IsComplete = task.IsComplete;

		return existing;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var task = await _context.Tasks.FindAsync(id);
		if (task == null) return false;

		_context.Tasks.Remove(task);
		return true;
	}

	public async Task<bool> ExistsAsync(int id)
	{
		return await _context.Tasks.AnyAsync(t => t.Id == id);
	}
}
