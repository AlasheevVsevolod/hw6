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
			//B6_P1();

			//B6-P2/6. 3DMassiveMaxInRow.
			B6_P2();

			Console.Read();
		}

		public static void B6_P1()
		{
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
		}

		public static void B6_P2()
		{
			const int rows = 3, cols = 3;
			int[,] newArr = new int[rows, cols];
			int[] maxNumbers = new int[3];
			Random randNum = new Random();

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					newArr[row, col] = randNum.Next(100);
					Console.Write($"{newArr[row, col]} ");

					if (maxNumbers[row] < newArr[row, col])
					{
						maxNumbers[row] = newArr[row, col];
					}
				}
				Console.WriteLine();
			}

			for(int i = 0; i < maxNumbers.Length; i++)
			{
				Console.WriteLine($"Max number in row {i} is {maxNumbers[i]}");
			}
		}

	}
}
