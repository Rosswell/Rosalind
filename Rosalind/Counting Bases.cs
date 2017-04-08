using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind
{
	public class Problem9
	{
		public static void Counting_Bases()
		{
			string line;
			StreamReader file =
				new StreamReader(File.Open("/Users/ross.blanchard/Downloads/rosalind_ini.txt", FileMode.Open, FileAccess.ReadWrite));
			//assigns line to the sequence 
			line = file.ReadLine();
			//turn the sequence into an array
			char[] bases = line.ToCharArray();
			//uses linq to count the base characters and assigns them to variables
			int c = bases.Count((char cc) => cc == 'C');
			int g = bases.Count((char gg) => gg == 'G');
			int t = bases.Count((char tt) => tt == 'T');
			int a = bases.Count((char aa) => aa == 'A');
			Console.WriteLine("{0} {1} {2} {3}", a, c, g, t);
		}
	}
}
