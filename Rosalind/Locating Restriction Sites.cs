using System;
namespace Rosalind
{
	public class Problem13
	{
		public static void locatingResrictionSites()
		{
			var sequence = ReadingFiles.readFasta();
			string strSequence = sequence[0];

			string forwardSubstring = "";
			string revSubstring = "";
			for (int startIndex = 0; startIndex < strSequence.Length; startIndex++)
			{
				for (int strLength = 1; strLength < 13; strLength++)
				{
					try
					{
						forwardSubstring = strSequence.Substring(startIndex, strLength);
						revSubstring = Complementing_a_Strand_of_DNA.ReverseComplement(forwardSubstring);
						if (forwardSubstring == revSubstring && forwardSubstring.Length < 13 && forwardSubstring.Length > 3)
						{
							Console.WriteLine("{0} {1}", startIndex + 1, strLength);
						}
					}
					catch (Exception)
					{
						break;
					}
				}
			}
		}
	}
}
