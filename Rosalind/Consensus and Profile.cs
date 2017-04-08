using System;
using System.Collections.Generic;
namespace Rosalind
{
	public class Problem19
	{
		public static void Consensus()
		{
			var seq = ReadingFiles.readFasta();

			char[][] SeqArray = new char[seq.Count][];

			for (var index = 0; index < seq.Count; index++)
				SeqArray[index] = seq[index].ToCharArray();

			//List<s
			foreach (var element in SeqArray)
				Console.WriteLine(element);
		}
	}
}
