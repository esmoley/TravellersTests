using System;
using System.Collections.Generic;
using System.Text;
using AdvancedTraveller.Enums;
using AdvancedTraveller.Structs;

namespace AdvancedTraveller.Models
{
    public class Unit
    {
        internal Position Position;
        internal DIRECTION Direction;
        internal List<Position> History;
        internal int[][] Cells;
        internal bool Stuck = false;
        internal bool Finished = false;
        internal List<int> PaidHistoryIndex;
        public Unit(Position position, DIRECTION direction, in int[][] cells)
        {
            History = new List<Position>() { position };
            PaidHistoryIndex = new List<int>();
            this.Position = position;
            this.Direction = direction;
            this.Cells = cells;

        }
        public Unit(Unit unit, DIRECTION direction)
        {
            History = new List<Position>(unit.History);
            Position = unit.Position;
            Cells = unit.Cells;
            PaidHistoryIndex = new List<int>(unit.PaidHistoryIndex);
            Direction = direction;
        }
    }
}
