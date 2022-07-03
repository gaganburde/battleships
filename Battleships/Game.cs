using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses

        public static Dictionary<Cell, int> ShipCoordinates { get; set; }

        public static Dictionary<int, int> ShipWithRemainingCellHitCount { get; set; }
        public static int Play(string[] ships, string[] guesses)
        {
            ShipCoordinates = new Dictionary<Cell, int>(new CellEqualityComaprer());
            ShipWithRemainingCellHitCount = new Dictionary<int, int>();
            IntializeShipCoordinates(ships);

            foreach (var guess in guesses)
            {
                var postionOfGuess = guess.Split(':');
                Cell guessCell = new Cell();
                guessCell.X = Convert.ToInt32(postionOfGuess[0]);
                guessCell.Y = Convert.ToInt32(postionOfGuess[1]);
                var isGuessCellExist = ShipCoordinates.ContainsKey(guessCell);
                if (isGuessCellExist)
                {
                    var value = ShipCoordinates[guessCell];
                    ShipWithRemainingCellHitCount[value] = ShipWithRemainingCellHitCount[value] - 1;
                    ShipCoordinates.Remove(guessCell);
                }

            }

            return ShipWithRemainingCellHitCount.Values.Count(x => x == 0);

        }

        private static void IntializeShipCoordinates(string[] ships)
        {
            int shipCount = 1;
            foreach (var ship in ships)
            {
                var s = new Ship();
                s.Id = shipCount;
                var allPostion = ship.Split(',');
                var shipStartPostion = allPostion[0].Split(':');
                var shipEndPostion = allPostion[1].Split(':');
                var shipStartRowNo = Convert.ToInt32(shipStartPostion[0]);
                var shipStartColumnNo = Convert.ToInt32(shipStartPostion[1]);
                var shipEndRowNo = Convert.ToInt32(shipEndPostion[0]);
                var shipEndColumnNo = Convert.ToInt32(shipEndPostion[1]);
                var noOfCellInShip = 0;

                for (int i = shipStartRowNo; i <= shipEndRowNo; i++)
                {
                    for (int j = shipStartColumnNo; j <= shipEndColumnNo; j++)
                    {
                        Cell cell = new Cell();
                        cell.X = i;
                        cell.Y = j;
                        ShipCoordinates.Add(cell, s.Id);
                        noOfCellInShip++;
                    }
                }
                shipCount++;
                ShipWithRemainingCellHitCount.Add(s.Id, noOfCellInShip);


            }
        }
    }
}
