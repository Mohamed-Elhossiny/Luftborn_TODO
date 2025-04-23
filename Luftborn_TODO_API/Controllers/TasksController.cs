using Luftborn_TODO_API.DTOs;
using Luftborn_TODO_API.Services;
using Luftborn_TODO_API.Services.TaskServices;
using Microsoft.AspNetCore.Mvc;

namespace Luftborn_TODO_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : TODOBaseController
{
	private readonly ITaskService _taskService;
	public TasksController(LogService logger, ITaskService taskService) : base(logger)
	{
		_taskService = taskService;
	}

	#region Query
	[HttpGet("GetTasks")]
	public async Task<IActionResult> GetTasks()
	{
		return await TryCatchLogAsync(async () =>
		{
			var tasks = await _taskService.GetAllTasksAsync();
			return Ok(tasks);
		});
	}

	[HttpGet("GetTaskById")]
	public async Task<IActionResult> GetTaskById(int id)
	{
		return await TryCatchLogAsync(async () =>
		{
			var task = await _taskService.GetTaskByIdAsync(id);
			return task != null ? Ok(task) : NotFound($"No task found with ID {id}");
		});
	}
	#endregion

	#region Command
	[HttpPost("AddTask")]
	public async Task<IActionResult> AddTask(AddTaskDto dto)
	{
		return await TryCatchLogAsync(async () =>
		{
			var task = await _taskService.AddTaskAsync(dto);
			return Ok(task);
		});
	}

	[HttpPost("UpdateTask")]
	public async Task<IActionResult> UpdateTask(UpdateTaskDto dto)
	{
		return await TryCatchLogAsync(async () =>
		{
			var task = await _taskService.UpdateTaskAsync(dto);
			return Ok(task);
		});
	}

	[HttpDelete("DeleteTask")]
	public async Task<IActionResult> DeleteTask(int id)
	{
		return await TryCatchLogAsync(async () =>
		{
			var task = await _taskService.DeleteTaskAsync(id);
			return Ok(task);
		});
	}
	#endregion
}
