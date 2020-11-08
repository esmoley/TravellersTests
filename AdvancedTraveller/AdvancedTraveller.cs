using System;
using System.Collections.Generic;
using Traveller;
using AdvancedTraveller.Models;
using AdvancedTraveller.Methods;
using AdvancedTraveller.Enums;
using AdvancedTraveller.Structs;

namespace AdvancedTraveller
{
    /// <summary>
    /// Продвинутый путешественник.
    /// Работает дольше, чем обычный путешественник, но способен найти лучший путь, т.к. перебирает все возможные варианты
    /// </summary>
    public class AdvancedTraveller : ITraveller
    {
        int ITraveller.Travel(int index, int[][] cells)
        {
            TravellerPrinter.PrintCells(index, cells);
            int price = GetMinTravelPrice(cells);
            TravellerPrinter.PrintPaidPrice(price);
            return price;
        }
        private static int GetMinTravelPrice(int[][] cells)
        {
            // добавляем двух юнитов, один двигается вниз, другой направо
            List<Unit> units = new List<Unit>() { new Unit(new Position(0,0), DIRECTION.DOWN, cells), new Unit(new Position(0,0), DIRECTION.RIGHT, cells) }; 

            // Двигаемся пока все юниты не достигли конца

            bool end = false;
            while (!end)
            {
                end = true;
                foreach(Unit unit in units)
                {
                    UnitMethods.Move(unit);
                    end = unit.Stuck || unit.Finished;
                }
                int unitsAdded = UnitMethods.AddNewUnits(ref units);
                end = end == true && unitsAdded==0;
                // удаление застрявших юнитов
                var newUnits = new List<Unit>();
                foreach(Unit unit in units)
                {
                    if (!unit.Stuck) newUnits.Add(unit);
                    //else Console.WriteLine("removed unit");
                }
                units = newUnits;
            }

            // Находим лучшего юнита
            Unit bestUnit = units[0];
            for(int i=1;i<units.Count;i++)
            {
                if (bestUnit.PaidHistoryIndex.Count > units[i].PaidHistoryIndex.Count)
                {
                    bestUnit = units[i];
                }
            }
            var bestUnitHistory = PositionMethods.ConvertListToTuples(bestUnit.History);
            TravellerPrinter.PrintUserRoute(bestUnitHistory);
            TravellerPrinter.PrintPaidRoute(bestUnit.PaidHistoryIndex, bestUnitHistory);
            return bestUnit.PaidHistoryIndex.Count;
        }

    }
}
