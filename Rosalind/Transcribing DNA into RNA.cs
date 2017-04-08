using System;
namespace Rosalind
{
	public class Transcribing_DNA_into_RNA
	{
		public static string Transcribing(string nucs)
{
			/*Console.WriteLine("what is the string of nucleotides?");
			var nucs = Console.ReadLine();*/

			char[] bases = nucs.ToCharArray();
			int basesLength = bases.Length;
			for (int baseIndex = 0; baseIndex < basesLength; baseIndex++)
			{
				if (bases[baseIndex] == 'T')
				{
					bases[baseIndex] = 'U';
				}
			}
			return bases.ToString();
			//Console.WriteLine(bases);
		}
	}
}
