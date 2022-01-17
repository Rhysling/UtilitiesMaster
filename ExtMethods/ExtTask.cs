using System;
using System.Threading.Tasks;

namespace UtilitiesMaster.ExtMethods.ExtTask
{
	public static class ExtTask
	{
		public static async void FireAndForget(this Task task)
		{
			try
			{
				await task.ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
	}
}
