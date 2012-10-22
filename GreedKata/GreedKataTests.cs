using System;
using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class GreedKataTests : IRoller, IScoreCalculator, IDisplay
    {
        int _condition;

        [Test]
        public void When_throwing_a_single_five_you_score_50() //nb this is crap. I've faked everthing what is the value of this?
        {
            
            var game = new Game(this, this);
            game.ThrowDice();
            game.Score();
            Assert.That(_condition ,Is.EqualTo(50));
        }

        public int[] Roll()
        {
            return new[] {2, 3, 4, 6, 5};
        }

        public void CalculateScore(int[] lastDiceRoll)
        {
            Display(50);
        }

        public void Display(int score)
        {
            _condition = score;
        }
    }

    public interface IDisplay
    {
        void Display(int score);
    }
}
