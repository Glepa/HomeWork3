using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            #region Задача про финансы
            string[] tabName = new string[] { "Номер месяца", "Доход", "Расход", "Прибыль" };
            int[,] financialTable = new int[12, 4];
            int[] profit = new int[12];
            int numMonthPositiveProfit = 0;
            foreach (var item in tabName)
            {
                Console.Write($"{ item,9}");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < financialTable.GetLength(0); i++)
            {
                for (int j = 0; j < financialTable.GetLength(1); j++)
                {
                    if (j == 0)
                        financialTable[i, j] = i + 1;

                    else if (j == 3)
                    {
                        financialTable[i, j] = financialTable[i, j - 1] - financialTable[i, j - 2];
                        profit[i] = financialTable[i, j];
                        numMonthPositiveProfit += financialTable[i, j] > 0 ? 1 : 0;
                    }
                    else
                        financialTable[i, j] = rand.Next(5000, 10000);
                    Console.Write($"{financialTable[i, j],10}");
                }
                Console.WriteLine();
            }
            Array.Sort(profit);
            Console.WriteLine("\n 3 Месяца с наименьшей прибылью:\n");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($" С прибылью {profit[i]}: ");
                for (int j = 0; j < financialTable.GetLength(0); j++)
                {
                    if (financialTable[j, 3] == profit[i])
                        Console.Write($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(financialTable[j, 0])}, ");
                }

                Console.Write("\b\b \n\n");
            }
            Console.WriteLine($"Колличество месяцев с положительной прибылью: {numMonthPositiveProfit}");
            Console.ReadKey();
            #endregion


            #region Треугольник Паскаля
            int size = 10;
            int[][] trianglePascal = new int[size][];
            for (int i = 0; i < size; i++)
            {
                trianglePascal[i] = new int[i + 1];
            }
            for (int i = 0; i < size; i++)
            {
                Console.Write("".PadLeft(size*2 - i,' '));
                for (int j = 0; j < trianglePascal[i].Length; j++)
                {
                    if (j == 0 || j == trianglePascal[i].Length - 1)
                        trianglePascal[i][j] = 1;
                    else
                        trianglePascal[i][j] = trianglePascal[i - 1][j - 1] + trianglePascal[i - 1][j];
                        Console.Write($"{trianglePascal[i][j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            #endregion

            
            #region Работа с матрицей
            int row = 3;
            int col = 3;
            int n = 4;
            int[,] matrix1 = new int[row, col];
            int[,] matrix2 = new int[col, row];
            int[,] matrixResulte = new int[row, col];
            Console.WriteLine("\n   Матрица 1:\n");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix1[i,j] = rand.Next(1, 3);
                    Console.Write($"{matrix1[i,j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n    Матрица 2:\n");
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    matrix2[i, j] = rand.Next(1, 3);
                    Console.Write($"{matrix2[i, j],4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\n  Умножение матрицы 1 на число {n}:\n");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrixResulte[i, j] = matrix1[i, j] * n;
                    Console.Write($"{matrixResulte[i, j],4}");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine($"\n  Сложение матрицы 1 с матрицей 2:\n");
            
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrixResulte[i, j] = matrix1[i, j] + matrix2[i, j];
                    Console.Write($"{matrixResulte[i, j],4}");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine($"\n  Вычитание матрицы 2 из матрицы 1:\n");

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrixResulte[i, j] = matrix1[i, j] - matrix2[i, j];
                        Console.Write($"{matrixResulte[i, j],4}");
                    }
                    Console.WriteLine();
                }
           
            Console.WriteLine($"\n  Умножение матрицы 1 на матрицу 2:\n");

            Array.Clear(matrixResulte, 0, matrixResulte.Length);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <row; j++)
                {
                    for (int k = 0; k < col; k++)
                    {
                        matrixResulte[i,j] += matrix1[i, k] * matrix2[k, j];
                    }
                        Console.Write($"{matrixResulte[i, j],4} ");
                }
                    Console.WriteLine();
            }
            #endregion
        }
    }
}
