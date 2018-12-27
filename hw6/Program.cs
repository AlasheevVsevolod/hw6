using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6
{
	class Program
	{
		static void Main(string[] args)
		{
			//B6 - P1 / 6. 1DReadConsoleMassive
			int[] newArr = new int[6];
			for (int i = 0; i < newArr.Length; i++)
			{
				Console.Write($"Введите число №{i}: ");
				newArr[i] = Convert.ToInt32(Console.ReadLine());
			}

			Console.WriteLine();
			for (int i = 0; i < newArr.Length; i++)
			{
				Console.WriteLine($"newArr[{i}]: {newArr[i]}");
			}

			Console.Read();
		}
	}
}
