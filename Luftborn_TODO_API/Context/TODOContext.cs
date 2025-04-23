using Luftborn_TODO_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Luftborn_TODO_API.Context;

public class TODOContext : DbContext
{
	public virtual DbSet<Tasks> Tasks { get; set; }
	public TODOContext() { }
	public TODOContext(DbContextOptions<TODOContext> options) : base(options) { }
}
