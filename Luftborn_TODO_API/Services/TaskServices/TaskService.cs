using Luftborn_TODO_API.Context.UnitOfWork;
using Luftborn_TODO_API.DTOs;
using Luftborn_TODO_API.Models;
using Luftborn_TODO_API.Repositories.TaskRepository;

namespace Luftborn_TODO_API.Services.TaskServices
{
	public class TaskService : ITaskService
	{
		private readonly IUnitOfWork _unitOfWork;

		public TaskService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
		{
			return await _unitOfWork.Tasks.GetAllAsync();
		}

		public async Task<Tasks?> GetTaskByIdAsync(int id)
		{
			return await _unitOfWork.Tasks.GetByIdAsync(id);
		}

		public async Task<bool> AddTaskAsync(AddTaskDto dto)
		{
			var task = new Tasks
			{
				Title = dto.Title,
				Description = dto.Description,
				IsComplete = dto.IsComplete
			};

			await _unitOfWork.Tasks.AddAsync(task);
			return await _unitOfWork.SaveChangesAsync() > 0;
		}

		public async Task<bool> UpdateTaskAsync(UpdateTaskDto dto)
		{
			var task = new Tasks
			{
				Id = dto.Id,
				Title = dto.Title,
				Description = dto.Description,
				IsComplete = dto.IsComplete
			};

			var updated = await _unitOfWork.Tasks.UpdateAsync(task);
			if (updated == null) return false;

			return await _unitOfWork.SaveChangesAsync() > 0;
		}

		public async Task<bool> DeleteTaskAsync(int id)
		{
			var deleted = await _unitOfWork.Tasks.DeleteAsync(id);
			if (!deleted) return false;

			return await _unitOfWork.SaveChangesAsync() > 0;
		}
	}
}
