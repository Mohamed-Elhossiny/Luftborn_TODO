namespace Luftborn_TODO_API.DTOs
{
	public class UpdateTaskDto
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public bool IsComplete { get; set; }
	}
}
