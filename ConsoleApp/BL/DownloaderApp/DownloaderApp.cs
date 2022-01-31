using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp.BL.DownloaderApp;

internal class DownloaderApp : IApp
{
	public bool InitApp() => true;

	public void RunApp()
	{
		SumPageSizesAsync().Wait();
	}

	public void ExitApp() => StandardAppExitRoutine.ExitApp();


	static readonly HttpClient s_client = new HttpClient
	{
		MaxResponseContentBufferSize = 10_000_000
	};

	static async Task SumPageSizesAsync()
	{
		var stopwatch = Stopwatch.StartNew();

		IEnumerable<Task<int>> downloadTasksQuery =
			from url in s_urlList
			select ProcessUrlAsync(url, s_client);

		List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

		int totalBytes = 0;
		while (downloadTasks.Any())
		{
			Task<int> finishedTask = await Task.WhenAny(downloadTasks);
			downloadTasks.Remove(finishedTask);
			totalBytes += await finishedTask;
		}

		stopwatch.Stop();

		Console.WriteLine($"\nTotal bytes returned:  {totalBytes:#,#}");
		Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
	}

	static async Task<int> ProcessUrlAsync(string url, HttpClient client)
	{
		Console.WriteLine($"{url,-60} ...");
		byte[] content = await client.GetByteArrayAsync(url);
		await new TaskTester().DoWork();
		Console.WriteLine($"{url,-60} {content.Length,10:#,#}");
		return content.Length;
	}

	public class TaskTester
	{
		public async Task DoWork()
		{
			var timer = new System.Threading.PeriodicTimer(TimeSpan.FromMilliseconds(100));
			int counter = 2;
			while (await timer.WaitForNextTickAsync() && counter > 0)
			{
				// Console.WriteLine(DateTime.UtcNow);
				counter--;
			}

			await Task.Factory.StartNew(() => { System.Threading.Thread.Sleep(1); });
			int res = await Task.FromResult<int>(GetSum(4, 5));
		}
		private int GetSum(int a, int b)
		{
			return a + b;
		}
	}

	static readonly IEnumerable<string> s_urlList = new string[]
	{
		"https://docs.microsoft.com",
		"https://google.de",
		"https://google.com",
		"https://winfuture.de",
		"https://heise.de",
		"https://geizhals.de",
		"https://amazon.de",
		"https://apple.com",
		"https://www.youtube.com/watch?v=bP1ucIly_lE",
		"https://deelay.me/2000/https://picsum.photos/1200/1300",
		"https://deelay.me/2000/https://picsum.photos/200/300",
		"https://deelay.me/1000/https://picsum.photos/200/300",
		"https://deelay.me/100/https://picsum.photos/200/300",
		"https://deelay.me/10/https://picsum.photos/200/300",
	};
}