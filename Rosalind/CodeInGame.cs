using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

	static void notMain(String[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] arr_temp = Console.ReadLine().Split(' ');
		char[] arr = new char[20];
		//foreach (var element in arr_temp)
			//if int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
		var positives = 0;
		var negatives = 0;
		var zeroes = 0;
		foreach (var element in arr)
		{
			if (element > 0)
			{ positives++; }
			else
			{
				if (element < 0)
				{ negatives++; }
				else
				{
					if (element == 0)
					{ zeroes++; }
				}
			}
		}
		var total = positives + negatives + zeroes;
		Console.WriteLine("{0}\n{1}\n{2}", positives / total, negatives / total, zeroes / total);
	}
}