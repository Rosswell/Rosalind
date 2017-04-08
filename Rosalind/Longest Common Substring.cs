using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Rosalind
{
	public static class Problem8
	{
		public static string GetLongestCommonSubstring(this IList<string> strings)
		{
			//exceptions for if an input string is empty or null
			if (strings == null)
				throw new ArgumentNullException("strings");
			if (!strings.Any() || strings.Any(s => string.IsNullOrEmpty(s)))
				throw new ArgumentException("None string must be empty", "strings");


			var commonSubstrings = new HashSet<string>(strings[0].GetSubstrings());
			foreach (string str in strings.Skip(1))
			{
				commonSubstrings.IntersectWith(str.GetSubstrings());
				if (commonSubstrings.Count == 0)
					return null;
			}
			return commonSubstrings.OrderByDescending(s => s.Length).First();
		}

		public static IEnumerable<string> GetSubstrings(this string str)
		{
			//exception for null or empty string
			if (string.IsNullOrEmpty(str))
				throw new ArgumentException("str must not be null or empty", "str");

			//
			for (int c = 0; c < str.Length - 1; c++)
			{
				for (int cc = 1; c + cc <= str.Length; cc++)
				{
					yield return str.Substring(c, cc);
				}
			}
		}

		public static void GetSequences()
		{
			string line;
			// Read the file and display it line by line.
			StreamReader file =
				new StreamReader(File.Open("/Users/ross.blanchard/Downloads/rosalind_lcsm.txt", FileMode.Open, FileAccess.ReadWrite));
			List<string> ATCG = new List<string>();
			List<string> sequence = new List<string>();
			int counter = 0;
			int ATCGIndex = 0;

			//while the file contains lines, parse those into sequences
			while ((line = file.ReadLine()) != null)
			{
				if (!line.StartsWith(">"))
				{
					sequence.Add(line);
				}
				else
				{
					if (counter > 0)
					{
						ATCG.Insert(ATCGIndex, string.Join("", sequence));
						sequence.Clear();
						ATCGIndex++;
					}
				}
				counter++;
			}
			ATCG.Insert(ATCGIndex, string.Join("", sequence));
			file.Dispose();
			//writes the sequence list to an array and applies the longest common substring method to it
			string[] x = ATCG.ToArray();
			int startIndex = 0;
			//string match1;
			//string match2;
			//bool noMatch = true;
			for (int subtrLength = 1; subtrLength < x[1].Length; subtrLength++)
			{
				for (string substr = x[1].Substring(startIndex, subtrLength); substr.Length <= x[1].Length; startIndex++)
				{
					foreach (string element in x)
					{
						if (!element.Contains(substr))
						{
							//noMatch = false;
							break;
						}
					}

					string LongestCommon = x.GetLongestCommonSubstring();
					Console.WriteLine(LongestCommon);

				}
			}
		}
	}
}
