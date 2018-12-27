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
			//B6-P1/6. 1DReadConsoleMassive
			//B6_P1();

			//B6-P2/6. 3DMassiveMaxInRow.
			//B6_P2();

			//B6-P3/6. 1DMasiveSort.
			B6_P3();

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

		public static void B6_P3()
		{
			int[] newArr = new int[5];
			int[] sortedArr = new int[5];
			Random randNum = new Random();

			for(int i = 0; i < newArr.Length; i++)
			{
				newArr[i] = randNum.Next(100);
				Console.Write($"{newArr[i]} ");
			}
			Console.WriteLine();

			//тут дублирую массив, тк он ссылочный тип, и если я передам в метод newArr,
			//  он изменится и использовать его не выйдет потом.
			Console.WriteLine("\nСортировка пузырьком");
			newArr.CopyTo(sortedArr, 0);
			BubbleSort(sortedArr);
			foreach (int element in sortedArr)
			{
				Console.Write($"{element} ");
			}
			Console.WriteLine();

			Console.WriteLine("\nСортировка вставкой");
			newArr.CopyTo(sortedArr, 0);
			sortedArr = InsertionSort(sortedArr);
			foreach (int element in sortedArr)
			{
				Console.Write($"{element} ");
			}
			Console.WriteLine();

			//Heapsort пока звучит сложновато
			//\todo Quicksort вроде понял, попробую позже


		}

		public static void BubbleSort(int[] tmpArr)
		{
			int tmpVar = 0;

			for (int i = 0; i < tmpArr.Length - 1; i++)
			{
				if (tmpArr[i + 1] < tmpArr[i])
				{
					tmpVar = tmpArr[i];
					tmpArr[i] = tmpArr[i + 1];
					tmpArr[i + 1] = tmpVar;

/*					//Хочу каждую итерацию видеть
					foreach (int element in tmpArr)
					{
						Console.Write($"{element} ");
					}
					Console.WriteLine();
*/
					BubbleSort(tmpArr);
				}
			}
		}

		public static int[] InsertionSort(int[] tmpArr)
		{
			int[] sortedArr = new int[tmpArr.Length];
			int tmpArrEnum, sortedArrEnum;

			sortedArr[0] = tmpArr[0];
			for (tmpArrEnum = 1; tmpArrEnum < tmpArr.Length; tmpArrEnum++)
			{
				for (sortedArrEnum = 0; sortedArrEnum < sortedArr.Length; sortedArrEnum++)
				{
					if(tmpArr[tmpArrEnum] <= sortedArr[sortedArrEnum])
					{
						int i = 0;
						while (sortedArr.Length - sortedArrEnum - i - 1 > 0)
						{
							sortedArr[sortedArr.Length - 1 - i] = sortedArr[sortedArr.Length - 2 - i++];
						}
						sortedArr[sortedArrEnum] = tmpArr[tmpArrEnum];
						break;
					}
				}
				if (sortedArrEnum == sortedArr.Length)
				{
					sortedArr[tmpArrEnum] = tmpArr[tmpArrEnum];
				}
				//Как-то громоздко получилось, мб можно проще

/*				//Хочу каждую итерацию видеть
				foreach (int element in sortedArr)
				{
					Console.Write($"{element} ");
				}
				Console.WriteLine();
*/
			}
			return sortedArr;
		}

	}
}
