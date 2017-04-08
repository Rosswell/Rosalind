using System;
using System.Linq;
using System.Collections.Generic;

namespace Rosalind
{
	public class Counting_DNA_Nucleotides
	{
		public static void Counting()
		{
			int cCount = 0;
			int gCount = 0;
			int tCount = 0;
			int aCount = 0;
			Console.WriteLine("what is the string of nucleotides?");
			var nucs = Console.ReadLine();
			char[] bases = nucs.ToCharArray();
			//Console.WriteLine(bases);
			foreach (char element in bases)
			{
				switch (element)
				{
					case 'C':
						cCount = cCount + 1;
						break;
					case 'G':
						gCount = gCount + 1;
						break;
					case 'T':
						tCount = tCount + 1;
						break;
					case 'A':
						aCount = aCount + 1;
						break;
				}
			}
			Console.WriteLine("{0} {1} {2} {3}", aCount, cCount, gCount, tCount);
			Console.ReadKey();
		}
	}
}
