using System;
using System.Collections.Generic;

namespace Rosalind
{
	public class Complementing_a_Strand_of_DNA
	{
		public static string Reversal(string forward)
		{
			char[] charArray = forward.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
		public static string ReverseComplement(string x)
		{
			//Console.WriteLine("What is the strand of DNA?");
			string DNA = x;
			string reverseDNA = Reversal(DNA);
			char[] arrDNA = reverseDNA.ToCharArray();
			int DNALength = DNA.Length;
			//Console.WriteLine(arrDNA);
			for (int arrIndex = 0; arrIndex < DNALength; arrIndex++)
			{
				if (arrDNA[arrIndex] == 'T')
				{
					arrDNA[arrIndex] = 'A';
				}
				else
				{
					if (arrDNA[arrIndex] == 'A')
					{
						arrDNA[arrIndex] = 'T';
					}
					else
					{
						if (arrDNA[arrIndex] == 'G')
						{
							arrDNA[arrIndex] = 'C';
						}
						else
						{

							if (arrDNA[arrIndex] == 'C')
							{
								arrDNA[arrIndex] = 'G';
							}
						}
					}
				}
			}
			//foreach (var element in arrDNA) { Console.WriteLine(element); }
			string strDNA = "";
			foreach (var element in arrDNA) { strDNA = strDNA + element; }
			return strDNA;
		}
	}
}
