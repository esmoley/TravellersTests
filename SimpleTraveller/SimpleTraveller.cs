using System;
using System.Collections.Generic;
using Traveller;

namespace SimpleTraveller
{
    /// <summary>
    /// Обычный путешественник.
    /// Путешествует вниз или вправо в зависимости от значения в ячейке.
    /// Приоритет движения - вниз
    /// </summary>
    public class SimpleTraveller : ITraveller
    {
        int ITraveller.Travel(int index, int[][] cells)
        {
            TravellerPrinter.PrintCells(index, cells);
            int price = GetMinTravelPrice(cells);
            TravellerPrinter.PrintPaidPrice(price);
            return price;
        }
        private static void SetPosition(List<(int, int)> userRoute, ref (int, int) currentPosition, (int, int) desirablePosition)
        {
            currentPosition = desirablePosition;
            userRoute.Add(desirablePosition);
        }
        private static int GetMinTravelPrice(int[][] cells)
        {
            List<(int, int)> userRoute = new List<(int, int)>() { (0, 0) };
            List<int> paidUserRouteFrom = new List<int>();

            (int, int) finishPosition = (cells.Length - 1, cells[0].Length - 1);
            (int, int) currentPosition = (0, 0);

            while (currentPosition != finishPosition)
            {
                int currentValue = cells[currentPosition.Item1][currentPosition.Item2]; // Значение в ячейке

                int nextRow = currentPosition.Item1 + 1;

                bool tollDownAndNoWall = false; // Нет стены, но чтобы двигаться вниз, нужно оплатить. Флаг на тот случай, если справа стена

                if (nextRow < cells.Length) // Если внизу нет стены
                {
                    if (currentValue != cells[nextRow][currentPosition.Item2]) tollDownAndNoWall = true; // Чтобы двигаться вниз, необходима оплата - ставим флаг. Далее проверяем что у нас справа
                    else
                    {
                        SetPosition(userRoute, ref currentPosition, (nextRow, currentPosition.Item2)); // Внизу путь свободный. Двигаемся
                        continue;
                    }
                }

                int nextColumn = currentPosition.Item2 + 1;
                if (nextColumn < cells[0].Length) // Если справа нет стены
                {
                    // Если надо оплатить, оплачиваем
                    if (currentValue != cells[currentPosition.Item1][nextColumn])
                    {
                        paidUserRouteFrom.Add(userRoute.Count);
                    }

                    SetPosition(userRoute, ref currentPosition, (currentPosition.Item1, nextColumn)); // Двигаемся дальше
                    continue;
                }
                else if (tollDownAndNoWall) // Сюда попадаем, только если справа стена, но чтобы двигаться вниз - нужно оплатить
                {
                    paidUserRouteFrom.Add(userRoute.Count); // оплачиваем
                    SetPosition(userRoute, ref currentPosition, (nextRow, currentPosition.Item2)); // двигаемся дальше
                    continue;
                }
            }
            TravellerPrinter.PrintUserRoute(userRoute);
            TravellerPrinter.PrintPaidRoute(paidUserRouteFrom, userRoute);
            return paidUserRouteFrom.Count;
        }
    }
}
