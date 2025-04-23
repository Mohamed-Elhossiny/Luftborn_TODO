using Luftborn_TODO_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Luftborn_TODO_API.Controllers
{
	public class TODOBaseController : Controller
	{
		private readonly LogService _logger;

		public TODOBaseController(LogService logger)
		{
			this._logger = logger;
		}

		protected async Task<IActionResult> TryCatchLogAsync(Func<Task<IActionResult>> function)
		{
			try
			{
				return await function.Invoke();
			}
			catch (Exception ex)
			{
				this._logger.LogException($"{ex}\nStackTrace:\n{ex.StackTrace}\n ----InnerException----:\n{ex.InnerException}");
				return StatusCode(500, ex.InnerException?.Message);
			}
		}
	}
}
