using System;
using System.Collections.Generic;
namespace Rosalind
{
	public static class TranslationDictionary
	{
		public static string Translator(this string a)
		{
			//Dictionary contains the codons for RNA
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
			return RNACodonTable[a];
		}
		public static int TranslationCounts(this char a)
		{
			Dictionary<char, int> TranslationDict = new Dictionary<char, int>
			{
				{'F', 2},
				{'L', 6},
				{'S', 6},
				{'Y', 2},
				//{"Stop", 3},
				{'C', 2},
				{'W', 1},
				{'P', 4},
				{'H', 2},
				{'Q', 2},
				{'R', 6},
				{'I', 3},
				{'M', 1},
				{'T', 4},
				{'N', 2},
				{'K', 2},
				{'V', 4},
				{'A', 4},
				{'D', 2},
				{'E', 2},
				{'G', 4},
			};
			return TranslationDict[a];
		}
		public static double proteinWeight(this char a)
		{
			Dictionary<char, double> proteinWeightDict = new Dictionary<char, double>
			{
				{'F', 147.06841},
				{'L', 113.08406},
				{'S', 87.03203},
				{'Y', 163.06333},
				//{"Stop", 3},
				{'C', 103.00919},
				{'W', 186.07931},
				{'P', 97.05276},
				{'H', 137.05891},
				{'Q', 128.05858},
				{'R', 156.10111},
				{'I', 113.08406},
				{'M', 131.04049},
				{'T', 101.04768},
				{'N', 114.04293},
				{'K', 128.09496},
				{'V', 99.06841},
				{'A', 71.03711},
				{'D', 115.02694},
				{'E', 129.04259},
				{'G', 57.02146},
			};
			return proteinWeightDict[a];
		}
	}
}
