using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
namespace Rosalind
{
	public class Problem20
	{
		public static void ProteinMotif()
		{

			Task t = new Task(DownloadPageAsync);
			t.Start();
			Console.WriteLine("Downloading page...");
			Console.ReadLine();
		}
			static async void DownloadPageAsync()
			{
				// ... Target page.
			var uniprots = ReadingFiles.readFasta();
			string page = "http://www.uniprot.org/uniprot/" + uniprots[0] + ".fasta";

				// ... Use HttpClient.
				using (HttpClient client = new HttpClient())
				using (HttpResponseMessage response = await client.GetAsync(page))
				using (HttpContent content = response.Content)
				{
					// ... Read the string.
					string result = await content.ReadAsStringAsync();

					// ... Display the result.
					if (result != null &&
						result.Length >= 50)
					{
						Console.WriteLine(result.Substring(0, 50) + "...");
					}
				}
			}
	}
}
