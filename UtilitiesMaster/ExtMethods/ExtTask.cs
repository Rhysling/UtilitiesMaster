#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace UtilitiesMaster.ExtMethods.ExtTask;
#pragma warning restore IDE0130 // Namespace does not match folder structure

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
