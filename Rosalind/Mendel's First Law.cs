using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind
{
	public class Problem17
	{
		public static void Mendel()
		{
			string line;
			Console.WriteLine("what is the suffix to the rosalind file?");
			string dir = Console.ReadLine();
			// Read the file and display it line by line.
			Directory.SetCurrentDirectory("/Users/ross.blanchard/Downloads/");
			StreamReader file =
				new StreamReader(File.Open("rosalind_" + dir + ".txt", FileMode.Open, FileAccess.ReadWrite));
			line = file.ReadLine();

			var PhenotypeArray = line.Split(' ');

			float totalPeeps = 0;
			List<float> intList = new List<float>();
			foreach (var element in PhenotypeArray)
			{
				totalPeeps += Convert.ToInt32(element);
				intList.Add(float.Parse(element));
			}

			float HomoDom = 1;
			float Het = (intList[0] + (intList[1] - 1) * (float.Parse("0.75")) + (intList[2]) * (float.Parse("0.5")))/(totalPeeps - 1);
			float HomoRec = (intList[0] + (intList[1]) * (float.Parse("0.5"))) / (totalPeeps - 1);

			Console.WriteLine((HomoDom * intList[0] + Het * intList[1] + HomoRec  * intList[2])/totalPeeps);
		}
	}
}
