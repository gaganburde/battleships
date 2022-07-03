using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleships;
using FluentAssertions;
using Xunit;

namespace Battleships.Test
{
    public class GameTest
    {
        [Fact]
        public void TestPlay()
        {
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:3" };
            Game.Play(ships, guesses).Should().Be(0);
        }

        [Fact]
        public void TestPlayWithOneShip()
        {
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:2","3:3","3:4","3:5"};
            Game.Play(ships, guesses).Should().Be(1);
        }

        [Fact]
        public void TestPlayWithThreeShip()
        {
            var ships = new[] { "3:2,3:5","4:0,4:6","3:7,8:7"};
            var guesses = new[] { "3:3", "3:2", "3:4", "7:0", "3:5" ,"3:7","4:7","5:7","7:8","6:7","4:9","7:7","8:7"};
            Game.Play(ships, guesses).Should().Be(2);
        }

        [Fact]
        public void TestPlayWithFiveShip()
        {
            var ships = new[] { "7:5,7:7", "3:2,7:2", "1:6,1:9","1:4,1:5" ,"2:4,3:4"};
            var guesses = new[] { "4:4","5:2","3:2","1:7","7:6","1:9","1:6","4:2","7:7","7:2","1:8","4:7","1:4","8:4","8:8","6:2","0:0","2:1" ,"7:5","1:3","3:4","1:4","1:5","2:4","1:4"};
            Game.Play(ships, guesses).Should().Be(5);
        }
    }
}
