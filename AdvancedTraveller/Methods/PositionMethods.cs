using AdvancedTraveller.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTraveller.Methods
{
    public class PositionMethods
    {
        public static List<(int,int)> ConvertListToTuples(List<Position> positions)
        {
            List<(int, int)> ps = new List<(int, int)>();
            foreach (Position position in positions) ps.Add((position.A, position.B));
            return ps;
        }
    }
}
