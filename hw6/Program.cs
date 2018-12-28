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

			//B6-P4/6. *Pyatnashki.
			//B4_P6();

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

			for (int i = 0; i < maxNumbers.Length; i++)
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

			for (int i = 0; i < newArr.Length; i++)
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
					if (tmpArr[tmpArrEnum] <= sortedArr[sortedArrEnum])
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
			string[] stringArr;

			Console.WriteLine("Вводится четверостишие, строки разделяются символом \";\"");
			Console.WriteLine("Строка разбивается на массив строк с заменой символов");

			Console.Write("Введите стихотворение: ");
			consoleString = Console.ReadLine();

			stringArr = consoleString.Split(';');

			Console.WriteLine("\nОно же, но в красивой форме:");
			foreach (string arrItem in stringArr)
			{
				Console.WriteLine(arrItem);
			}

			Console.WriteLine("\nОно же, но с заменой символов:");
			stringArr = consoleString.Replace('о', 'а').Replace("л", "ль").Replace("ть", "т").Split(';');
			foreach (string arrItem in stringArr)
			{
				Console.WriteLine(arrItem);
			}
		}


		//B6-P4/6. *Pyatnashki.
		public static void B4_P6()
		{
			const int AUTHOR_SCORE = 191;
			int[,] playfield = new int[4, 4]
			{
				{9,2,7,11},
				{0,1,4,10},
				{5,3,12,6},
				{15,13,8,14}
			};
			int[] currentPosition = new int[2];
			int tmpVar = 0, userScore = 0;
			ConsoleKey Button;

			Console.WriteLine("Навигация стрелками");

			PrintField(playfield, out currentPosition);

			while (CheckCurrentField(playfield) == false)
			{
				Button = Console.ReadKey().Key;

				switch ((int)Button)
				{
					case 37:
						//LeftArrow = 37
						if (currentPosition[0] > 0)
						{
							userScore++;
							tmpVar = playfield[currentPosition[1], currentPosition[0] - 1];
							playfield[currentPosition[1], currentPosition[0] - 1] = 0;
							playfield[currentPosition[1], currentPosition[0]] = tmpVar;
						}
						break;

					case 38:
						//UpArrow = 38
						if (currentPosition[1] > 0)
						{
							userScore++;
							tmpVar = playfield[currentPosition[1] - 1, currentPosition[0]];
							playfield[currentPosition[1] - 1, currentPosition[0]] = 0;
							playfield[currentPosition[1], currentPosition[0]] = tmpVar;
						}
						break;

					case 39:
						//RightArrow = 39
						if (currentPosition[0] < 3)
						{
							userScore++;
							tmpVar = playfield[currentPosition[1], currentPosition[0] + 1];
							playfield[currentPosition[1], currentPosition[0] + 1] = 0;
							playfield[currentPosition[1], currentPosition[0]] = tmpVar;
						}
						break;

					case 40:
						//DownArrow = 40
						if (currentPosition[1] < 3)
						{
							userScore++;
							tmpVar = playfield[currentPosition[1] + 1, currentPosition[0]];
							playfield[currentPosition[1] + 1, currentPosition[0]] = 0;
							playfield[currentPosition[1], currentPosition[0]] = tmpVar;
						}
						break;

					default:
						break;
				}
				PrintField(playfield, out currentPosition);
			}
			Console.WriteLine("\nВы победили! Мои поздравления!!!\n");
			Console.WriteLine("Спортивного интереса ради:");
			Console.WriteLine($"Рекорд автора: {AUTHOR_SCORE} шаг");
			Console.WriteLine($"Ваш результат: {userScore}");
			}

		public static void PrintField(int[,] playfield, out int[] currentPosition)
		{
			currentPosition = new int[2] { 0, 0 };

			Console.Clear();
			Console.WriteLine("Навигация стрелками\n");
			for (int i = 0; i < playfield.GetLength(0); i++)
			{
				Console.WriteLine("-------------");
				for (int j = 0; j < playfield.GetLength(1); j++)
				{
					if (playfield[i, j] == 0)
					{
						currentPosition[0] = j;
						currentPosition[1] = i;

						Console.Write("|");
						Console.BackgroundColor = ConsoleColor.Gray;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.Write($"{playfield[i, j]:D2}");
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else
					{
						Console.Write($"|{playfield[i, j]:D2}");
					}
				}
				Console.Write("|\n");
			}
			Console.WriteLine("-------------");
		}

		public static bool CheckCurrentField(int[,]playfield) 
		{
			for (int i = 0; i < playfield.GetLength(0); i++)
			{
				for (int j = 0; j < playfield.GetLength(1); j++)
				{
					if (playfield[i, j] != playfield.GetLength(0) * i + j)
					{
						return false;
					}
				}
			}
			return true;
		}

	}
}
