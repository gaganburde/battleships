using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
   public struct Cell
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
    public struct CellEqualityComaprer : IEqualityComparer<Cell>
    {
        public bool Equals(Cell x, Cell y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Cell obj)
        {
            return obj.X + obj.Y;
        }
    }

}
