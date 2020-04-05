using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧисАнМетодЗейделя
{
    class Program
    {
        static void Zeidel(int size, double eps, double[,]matrix)
        {
            double[] previousX = new double[size];
            for (int i = 0; i < size; i++)
            {
                previousX[i] = 0.0;
            }
            int count = 0;
            double error = 0.0;
            do
            {

                double[] nowX = new double[size];

                for (int i = 0; i < size; i++)
                {
                    nowX[i] = matrix[i, size];


                    for (int j = 0; j < size; j++)
                    {
                        if (j < i)
                        {
                            nowX[i] -= matrix[i, j] * nowX[j];
                        }

                        if (j > i)
                        {
                            nowX[i] -= matrix[i, j] * previousX[j];
                        }
                    }

                    nowX[i] /= matrix[i, i];


                }

                error = 0.0;
                for (int i = 0; i < size; i++)
                {
                    error += Math.Abs(nowX[i] - previousX[i]);
                }


                previousX = nowX;
                count++;
                Console.WriteLine(count + "я итерация" + "\nОшибка: " + error + "\nРешения системы:");
                for (int i = 0; i < size; i++)
                {

                    Console.WriteLine("x" + (i + 1) + " " + previousX[i] + " ");
                }


            } while (error >= eps);

           
            Console.WriteLine("Общее количество итераций: " + count);
            
        }
        static void Main(string[] args)
        {
            
            int size = 4;
            double eps = 0.000000000001;
            double[,]matrix =
            {
                {76, 21, 6, -34, -142},
                {12, -114, 8, 9, 83},
                {16, 24, -100, -35, -121},
                {23, -8, 5, -75, 85}
            };
            Console.WriteLine("----------matrix --------");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Zeidel(size, eps, matrix);
            Console.ReadLine();

           
        }
    }
}
