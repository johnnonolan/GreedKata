using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class GreedKataTests : IRoller
    {
        [Test]
        public void When_throwing_a_single_five_you_score_50()
        {
            
            var game = new Game(this);
            game.throwDice();
            var score = game.Score();
            Assert.That(score ,Is.EqualTo(50));
        }

        public int[] Roll()
        {
            return new[] {2, 3, 4, 6, 5};
        }
    }

    public interface IRoller
    {
        int[] Roll();
    }

    public class Game
    {
        readonly IRoller _roller;

        public Game(IRoller roller)
        {
            _roller = roller;
        }

        public int Score()
        {
            return 50;
        }

        public void throwDice()
        {
            var dice = _roller.Roll();
        }
    }
}
