using System;
using Ionic.Zip;
using Ionic.Zlib;
using Ionic.Crc;
using Ionic.BZip2;
using System.Security;

namespace Ionic.Zip.Examples
{
	public class CreateZip
	{
		private static void Usage()
		{
			Console.WriteLine("usage:\n  CreateZip <ZipFileToCreate> <directory>");
			Environment.Exit(1);
		}

		public static void Main(String[] args)
		{
			
			if (args.Length != 2) Usage();
			if (!System.IO.Directory.Exists(args[1]))
			{
				Console.WriteLine("The directory does not exist!\n");
				Usage();
			}
			if (System.IO.File.Exists(args[0]))
			{
				Console.WriteLine("That zipfile already exists!\n");
				Usage();
			}
			if (!args[0].EndsWith(".zip"))
			{
				Console.WriteLine("The filename must end with .zip!\n");
				Usage();
			}

			string ZipFileToCreate = args[0];
			string DirectoryToZip = args[1];
			try
			{
				using (ZipFile zip = new ZipFile())
				{
					// note: this does not recurse directories! 
					String[] filenames = System.IO.Directory.GetFiles(DirectoryToZip);

					// This is just a sample, provided to illustrate the DotNetZip interface.  
					// This logic does not recurse through sub-directories.
					// If you are zipping up a directory, you may want to see the AddDirectory() method, 
					// which operates recursively. 
					foreach (String filename in filenames)
					{
						Console.WriteLine("Adding {0}...", filename);
						ZipEntry e = zip.AddFile(filename);
						e.Comment = "Added by Cheeso's CreateZip utility.";
					}

					zip.Comment = String.Format("This zip archive was created by the CreateZip example application on machine '{0}'",
					   System.Net.Dns.GetHostName());

					zip.Save(ZipFileToCreate);
				}

			}
			catch (System.Exception ex1)
			{
				System.Console.Error.WriteLine("exception: " + ex1);
			}

		}
	}
}
