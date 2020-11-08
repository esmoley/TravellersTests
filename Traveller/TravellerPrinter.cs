using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller
{
    public class TravellerPrinter
    {
        public static void PrintCells(int index, int[][] cells)
        {
            Console.WriteLine($"Пример {index}:");
            Console.WriteLine("cells = [");
            for (int i = 0; i < cells.Length; i++)
            {
                Console.Write("[");
                for(int j = 0; j < cells[0].Length; j++)
                {
                    if (j != 0) Console.Write(", ");
                    Console.Write(cells[i][j]);
                }
                Console.WriteLine("],");
            }
            Console.WriteLine("]");
        }
        public static void PrintUserRoute(List<(int, int)> userRoute)
        {
            Console.Write("Оптимальный маршрут: [");
            for(int i = 0; i < userRoute.Count; i++)
            {
                if (i != 0) Console.Write(", ");
                Console.Write(userRoute[i]);
            }
            Console.WriteLine("]");
        }
        public static void PrintPaidPrice(int price)
        {
            Console.WriteLine($"Ответ: {price}");
        }
        public static void PrintPaidRoute(List<int> paidRoute, List<(int,int)> userRoute)
        {
            if (paidRoute.Count > 0)
            {
                Console.Write("Комментарий: Переход из");
                for(int i=0;i<paidRoute.Count;i++)
                {
                    if (i != 0) Console.Write(",");
                    Console.Write($" ({userRoute[paidRoute[i]-1].Item1},{userRoute[paidRoute[i]-1].Item2}) в ({userRoute[paidRoute[i]].Item1},{userRoute[paidRoute[i]].Item2})");
                }
                string costWord = paidRoute.Count.ToString()+" монеток";
                if (paidRoute.Count == 1) costWord = "одну монетку";
                else if (paidRoute.Count == 2) costWord = "две монетки";
                else if (paidRoute.Count == 3) costWord = "три монетки";
                else if (paidRoute.Count == 4) costWord = "четыре монетки";
                else if (paidRoute.Count == 5) costWord = "пять монеток";
                else if (paidRoute.Count == 6) costWord = "шесть монеток";
                else if (paidRoute.Count == 7) costWord = "семь монеток";
                else if (paidRoute.Count == 8) costWord = "восемь монеток";
                else if (paidRoute.Count == 9) costWord = "девять монеток";
                Console.WriteLine($" стоит {costWord}");


            }
        }
    }
}
