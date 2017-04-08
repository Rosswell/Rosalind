using System;
namespace Rosalind
{
	public class Problem15
	{
		public static void TransitionsTransversions()
		{
			var sequences = ReadingFiles.readFasta();
			var seq1 = sequences[0].ToCharArray();
			var seq2 = sequences[1].ToCharArray();

			double transition = 0;
			double transversion = 0;

			for (int seqIndex = 0; seqIndex < seq1.Length; seqIndex++)
			{
				if (seq1[seqIndex] != seq2[seqIndex])
				{
					if ((seq1[seqIndex] == 'A' && seq2[seqIndex] == 'G') || (seq1[seqIndex] == 'G' && seq2[seqIndex] == 'A') || (seq1[seqIndex] == 'C' && seq2[seqIndex] == 'T') || (seq1[seqIndex] == 'T' && seq2[seqIndex] == 'C'))
						transition = transition + 1;
					/*else
						if (seq1[seqIndex] == 'G' && seq2[seqIndex] == 'A')
						transition = transition + 1;
					else
							if (seq1[seqIndex] == 'C' && seq2[seqIndex] == 'T')
						transition = transition + 1;
					else
								if (seq1[seqIndex] == 'T' && seq2[seqIndex] == 'C')
						transition = transition + 1;*/
					else
						transversion = transversion + 1;
				}
			}

			Console.WriteLine(Convert.ToDecimal(transition/transversion));
		}
	}
}
