using AdvancedTraveller.Enums;
using AdvancedTraveller.Models;
using AdvancedTraveller.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTraveller.Methods
{
    public class UnitMethods
    {
        /// <summary>
        /// returns amount of added units
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public static int AddNewUnits(ref List<Unit> units)
        {
            List<Unit> newUnits = new List<Unit>();
            foreach(Unit unit in units)
            {
                if (unit.Stuck || unit.Finished) continue;
                DIRECTION direction1 = DIRECTION.DOWN;
                DIRECTION direction2 = DIRECTION.UP;
                if (unit.Direction == DIRECTION.DOWN || unit.Direction == DIRECTION.UP)
                {
                    direction1 = DIRECTION.LEFT;
                    direction2 = DIRECTION.RIGHT;
                }
                Position newPosition1 = GetNextPosition(unit.Position, direction1);
                if(!unit.History.Contains(newPosition1)) newUnits.Add(new Unit(unit, direction1));
                Position newPosition2 = GetNextPosition(unit.Position, direction2);
                if (!unit.History.Contains(newPosition2)) newUnits.Add(new Unit(unit, direction2));
            }
            units.AddRange(newUnits);
            return newUnits.Count;
        }
        public static void Move(Unit unit)
        {
            if (unit.Stuck || unit.Finished) return;

            Position newPosition = GetNextPosition(unit.Position, unit.Direction);
            if (IsOutOfBounds(newPosition, ref unit.Cells)) unit.Stuck = true;
            else if (unit.Cells[unit.Position.A][unit.Position.B] != unit.Cells[newPosition.A][newPosition.B]) unit.PaidHistoryIndex.Add(unit.History.Count);
            unit.Position = newPosition;
            unit.History.Add(unit.Position);
            if (IsFinished(unit.Position, ref unit.Cells)) unit.Finished = true;
            
        }
        private static bool IsFinished(Position position, ref int[][] cells)
        {
            return position.A == cells.Length - 1 && position.B == cells[0].Length - 1;
        }
        private static bool IsOutOfBounds(Position position, ref int[][]cells)
        {
            return position.A == cells.Length || position.B == cells[0].Length || position.A == -1 || position.B == -1;
        }
        private static Position GetNextPosition(Position position, DIRECTION direction)
        {
            Position newPosition = position;
            switch (direction)
            {
                case DIRECTION.DOWN:
                    newPosition.A += 1;
                    break;
                case DIRECTION.RIGHT:
                    newPosition.B += 1;
                    break;
                case DIRECTION.UP:
                    newPosition.A -= 1;
                    break;
                case DIRECTION.LEFT:
                    newPosition.B -= 1;
                    break;
            }
            return newPosition;
        }
    }
}
