using System;
using System.Collections.Generic;
namespace Rosalind
{
	public class Problem16
	{
		public static void UncontinguousMotif()
		{
			var sequences = ReadingFiles.readFasta();
			var seq1 = sequences[0];
			var seq2 = sequences[1].ToCharArray();

			var index = 0;
			List<string> allIndices = new List<string> ();
			//var allIndices = "";

			foreach (var element in seq2)
			{
				allIndices.Add(Convert.ToString(seq1.IndexOf(element, index) + 1));
				index = seq1.IndexOf(element, index) + 1;

			}
			var IndicesPrint = "";
			foreach (var element in allIndices)
				IndicesPrint = IndicesPrint + " " + element;

			Console.WriteLine(IndicesPrint);
			//need to delete the bits of teh string prior to the found element and then return the index of the next element + the amount of string removed
		}
	}
}
