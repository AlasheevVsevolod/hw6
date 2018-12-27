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
			//B6_P3();

			//B6-P5/6. CutString.
			//B6_P5();

			//B6-P6/6. ReplaceInPoem.
			B6_P6();

			Console.Read();
		}


		//B6-P1/6. 1DReadConsoleMassive
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


		//B6-P2/6. 3DMassiveMaxInRow.
		public static void B6_P2()
		{
			const int ROWS = 3, COLS = 3;
			int[,] newArr = new int[ROWS, COLS];
			int[] maxNumbers = new int[3];
			Random randNum = new Random();

			for (int row = 0; row < ROWS; row++)
			{
				for (int col = 0; col < COLS; col++)
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


		//B6-P3/6. 1DMasiveSort.
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


		//B6-P5/6. CutString.
		public static void B6_P5()
		{
			const int NUM_OF_CHARS = 13;

			string consoleString, newString;
			int numOfCharacters;

			Console.Write("Введите предложение: ");
			consoleString = Console.ReadLine();

			numOfCharacters = consoleString.Length;
			if (numOfCharacters > NUM_OF_CHARS)
			{
				newString = consoleString.Substring(0, NUM_OF_CHARS) + "...";
			}
			else
			{
				newString = consoleString;
			}
			Console.WriteLine(newString);
		}


		//B6-P6/6. ReplaceInPoem.
		public static void B6_P6()
		{
			string consoleString;
			string[] stringArr = new string[10];
			int wordCharCounter = 0, wordCounter = 0;

			Console.WriteLine("Вводится стихотворение, строки разделяются символом \";\"");
			Console.WriteLine("Строка разбивается на массив строк с заменой символов");

			Console.Write("Введите стихотворение: ");
			consoleString = Console.ReadLine();

			for (int i = 0; i < consoleString.Length; i++)
			{
				if (consoleString[i] == ';')
				{
					wordCharCounter++;
					stringArr[wordCounter++] = consoleString.Substring(i - wordCharCounter + 1, wordCharCounter);
					wordCharCounter = 0;
				}
				else
				{
					wordCharCounter++;
				}
			}

			Console.WriteLine("\nОно же, но в красивой форме:");
			for (int i = 0; i < wordCounter; i++)
			{
				Console.WriteLine(stringArr[i]);
				stringArr[i] = stringArr[i].Replace('о', 'а').Replace("л", "ль").Replace("ть", "т");
			}

			Console.WriteLine("\nОно же, но с заменой символов:");
			for (int i = 0; i < wordCounter; i++)
			{
				Console.WriteLine(stringArr[i]);
			}
		}

	}
}
