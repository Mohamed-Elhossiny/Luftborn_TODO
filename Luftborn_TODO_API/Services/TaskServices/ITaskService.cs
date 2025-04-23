using Luftborn_TODO_API.DTOs;
using Luftborn_TODO_API.Models;

namespace Luftborn_TODO_API.Services.TaskServices;

public interface ITaskService
{
	Task<IEnumerable<Tasks>> GetAllTasksAsync();
	Task<Tasks?> GetTaskByIdAsync(int id);
	Task<bool> AddTaskAsync(AddTaskDto dto);
	Task<bool> UpdateTaskAsync(UpdateTaskDto dto);
	Task<bool> DeleteTaskAsync(int id);
}
