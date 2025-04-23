namespace Luftborn_TODO_API.Services
{
	public class LogService
	{
		private static readonly object LockLogObj = new object();

		private readonly IConfiguration Configuration;

		public LogService(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void LogException(string ex)
		{
			string currentDate = DateTime.Now.ToString("yyyyMMdd");
			string fileName = currentDate + "_log.txt";

			WriteToTextFile(ex, fileName);
		}

		#region Private
		private void WriteToTextFile(string ex_Txt, string fileName)
		{
			if (!Directory.Exists(this.LogsPath))
				Directory.CreateDirectory(this.LogsPath);

			lock (LockLogObj)
			{
				File.AppendAllText(Path.Combine(this.LogsPath, fileName), DateTime.Now.ToString() + Environment.NewLine + ex_Txt + Environment.NewLine + Environment.NewLine);
			}
		}

		private string LogsPath
		{
			get
			{
				return this.Configuration["LogsPath"]!;
			}
		}
		#endregion
	}
}
