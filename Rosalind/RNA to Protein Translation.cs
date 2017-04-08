using System;
using System.Collections.Generic;
using System.IO;

namespace Rosalind
{
	static class Problem6
	{
		public static IEnumerable<string> cutting(this string s, Int32 partLength)
		{
			//parses the input string into an array of substring with length partLength
			for (var i = 0; i < s.Length; i += partLength)
				yield return s.Substring(i, Math.Min(partLength, s.Length - i));
		}

		//public static 
		public static void RNATranslation()
		{
			//opens the file an reads the line
			StreamReader file =
				new StreamReader(File.Open("/Users/ross.blanchard/Downloads/rosalind_prot.txt", FileMode.Open, FileAccess.ReadWrite));

			var line = file.ReadLine();
			file.Dispose();
			//Dictionary contains the codons for RNA. Stop codons translated as empty strings
			Dictionary<string, string> RNACodonTable = new Dictionary<string, string>
			{
				{"UUU", "F"},
				{"UUC", "F"},
				{"UUA", "L"},
				{"UUG", "L"},
				{"UCU", "S"},
				{"UCC", "S"},
				{"UCA", "S"},
				{"UCG", "S"},
				{"UAU", "Y"},
				{"UAC", "Y"},
				{"UAA", ""},
				{"UAG", ""},
				{"UGU", "C"},
				{"UGC", "C"},
				{"UGA", ""},
				{"UGG", "W"},
				{"CUU", "L"},
				{"CUC", "L"},
				{"CUA", "L"},
				{"CUG", "L"},
				{"CCU", "P"},
				{"CCC", "P"},
				{"CCA", "P"},
				{"CCG", "P"},
				{"CAU", "H"},
				{"CAC", "H"},
				{"CAA", "Q"},
				{"CAG", "Q"},
				{"CGU", "R"},
				{"CGC", "R"},
				{"CGA", "R"},
				{"CGG", "R"},
				{"AUC", "I"},
				{"AUU", "I"},
				{"AUA", "I"},
				{"AUG", "M"},
				{"ACU", "T"},
				{"ACC", "T"},
				{"ACA", "T"},
				{"ACG", "T"},
				{"AAU", "N"},
				{"AAC", "N"},
				{"AAA", "K"},
				{"AAG", "K"},
				{"AGU", "S"},
				{"AGC", "S"},
				{"AGA", "R"},
				{"AGG", "R"},
				{"GUU", "V"},
				{"GUC", "V"},
				{"GUA", "V"},
				{"GUG", "V"},
				{"GCU", "A"},
				{"GCC", "A"},
				{"GCA", "A"},
				{"GCG", "A"},
				{"GAU", "D"},
				{"GAC", "D"},
				{"GAA", "E"},
				{"GAG", "E"},
				{"GGU", "G"},
				{"GGC", "G"},
				{"GGA", "G"},
				{"GGG", "G"},
			};

			var proteins = line.cutting(3);
			//assigns the RNA sequence, cut into 3s, into a list 
			List<string> translatedProteins = new List<string>();
			foreach (string element in proteins) { translatedProteins.Add(element); }

			string result = "";
			//returns the value for each key where key = the cut up RNA sequence and 
			// value = the corresponding letter from the dictionary
			foreach (var element in translatedProteins)
			{
				result = result + RNACodonTable[element];
			}
			Console.WriteLine(result);
		}
	}
}
