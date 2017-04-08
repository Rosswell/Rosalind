using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rosalind
{
	public class Problem10
	{
		public static void ORFs()
		{
			string line;
			//Open the file and allow RW
			StreamReader file =
				new StreamReader(File.Open("/Users/ross.blanchard/Downloads/rosalind_orf.txt", FileMode.Open, FileAccess.ReadWrite));
			string nucs = "";
			//while the file contains lines, parse the one sequence into a string. 

			while ((line = file.ReadLine()) != null)
			{
				if (!line.StartsWith(">"))
				{
					nucs = line;
				}
			}
			file.Dispose();
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
				{"UAA", "Stop"},
				{"UAG", "Stop"},
				{"UGU", "C"},
				{"UGC", "C"},
				{"UGA", "Stop"},
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
			List<string> allAminoAcids = new List<string>();
			nucs = nucs.Replace('T', 'U');
			var forwardNucs = nucs;
			var reverseNucs = Complementing_a_Strand_of_DNA.ReverseComplement(nucs);
			//reverse strand
			List<string> strReverseNucs = new List<string>(reverseNucs.Split());
			char[] chrReverseNucs = reverseNucs.ToCharArray();
			int index1 = 0;
			int index2 = 1;
			for (int index3 = 2; index3 < chrReverseNucs.Length;)
			{
				if (string.Join("", Convert.ToString(chrReverseNucs[index1]) + Convert.ToString(chrReverseNucs[index2]) + Convert.ToString((chrReverseNucs[index3]))) == "AUG")
				{
					strReverseNucs = chrReverseNucs.Select(c => c.ToString()).ToList();
					int startCodonIndex = index1;
					int stopCodonIndex = 0;
					//deletes bases prior to start codon
					strReverseNucs.RemoveRange(0, startCodonIndex);
					StringBuilder builder = new StringBuilder();
					foreach (string element in strReverseNucs) { builder.Append(element); }
					string internalStringTemp = builder.ToString();
					List<string> internalString = new List<string>(internalStringTemp.cutting(3));
					foreach (var element in internalString)
					{
						if (element == "UAA" || element == "UAG" || element == "UGA")
						{
							stopCodonIndex = internalString.IndexOf(element);
							break;
						}
					}
					var dictLookup = internalString.GetRange(0, stopCodonIndex);
					var result = "";
					foreach (var element in dictLookup)
					{
						result = result + RNACodonTable[element];
					}
					//determines if the string already exists within the amino acid list, then adds it if it doesnt
					bool alreadyExists = allAminoAcids.Contains(result);
					if (alreadyExists == false)
						allAminoAcids.Add(result);
				}
				index1++;
				index2++;
				index3++;
			}

			//forward strand
			List<string> strForwardNucs = new List<string>(forwardNucs.Split());
			char[] chrForwardNucs = forwardNucs.ToCharArray();
			int index4 = 0;
			int index5 = 1;
			for (int index6 = 2; index6 < chrForwardNucs.Length;)
				{
					if (string.Join("", Convert.ToString(chrForwardNucs[index4]) + Convert.ToString(chrForwardNucs[index5]) + Convert.ToString((chrForwardNucs[index6]))) == "AUG")
					{
						strForwardNucs = chrForwardNucs.Select(c => c.ToString()).ToList();
						int startCodonIndex = index4;
						int stopCodonIndex = 0;
						//deletes bases prior to start codon
						strForwardNucs.RemoveRange(0, startCodonIndex);
						StringBuilder builder = new StringBuilder();
						foreach (string element in strForwardNucs) { builder.Append(element); }
						string internalStringTemp = builder.ToString();
						List<string> internalString = new List<string>(internalStringTemp.cutting(3));
						foreach (var element in internalString)
						{
							if (element == "UAA" || element == "UAG" || element == "UGA")
							{
								stopCodonIndex = internalString.IndexOf(element);
							break;
							}
						}
						var dictLookup = internalString.GetRange(0, stopCodonIndex);
						var result = "";
						foreach (var element in dictLookup)
						{
							result = result + RNACodonTable[element];
						}
					bool alreadyExists = allAminoAcids.Contains(result);
					if (alreadyExists == false)
						allAminoAcids.Add(result);
					}
				index4++;
				index5++;
				index6++;
			}
			foreach (var element in allAminoAcids) { Console.WriteLine(element); }
		}
	}
}
