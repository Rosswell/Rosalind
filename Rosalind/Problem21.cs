using System;
using System.IO;
namespace Rosalind
{
	public class Problem21
	{
		public static void ChangeFile()
		{
			string line;
			//Console.WriteLine("what is the path to the file?");
			string dir = "/Users/ross.blanchard/.bash_profile";
			// Read the file and display it line by line.
			//Directory.SetCurrentDirectory("/Users/ross.blanchard/Downloads/");
			StreamReader file =
				new StreamReader(File.Open(dir, FileMode.Open, FileAccess.ReadWrite));
			while ((line = file.ReadLine()) != null)
			{
				if (line.StartsWith("export"))
				{
					line = "export PATH=\"$PATH:/ home / your_user /.local / bin\"";
				}
			}
			file.Dispose();
			Console.WriteLine("Build completed");
		}
	}
}
