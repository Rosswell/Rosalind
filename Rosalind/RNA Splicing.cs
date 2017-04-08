using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Rosalind
{
	public class Problem14
	{
		public static void RNASplicing()
		{
			//reads the fasta file and assigns to sequence list
			var sequences = ReadingFiles.readFasta();
			var exons = sequences[0];
			//replaces the introns - indices 1+ - from the exons - index 1 - with  empty strings
			for (int sequencesIndex = 1; sequencesIndex < sequences.Count; sequencesIndex++)
			{
				exons = exons.Replace(sequences[sequencesIndex], "");
			}
			//translates DNA into RNA
			exons = exons.Replace('T', 'U');
			//cuts the RNA into strings of 3
			List<string> exonAAs = new List<string>(exons.cutting(3));
			//translates RNA into amino acids
			List<string> uncutExons = new List<string>();
			foreach (var element in exonAAs)
			{
				uncutExons.Add(TranslationDictionary.Translator(element));
			}
			//converts the list into a string and prints out the string
			string strExons = "";
			foreach (var element in uncutExons)
				strExons = strExons + element;
			Console.WriteLine(strExons);
		}
	}
}
