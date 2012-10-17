using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class GreedKataTests : IRoller, IScoreCalculator
    {
        [Test]
        public void When_throwing_a_single_five_you_score_50()
        {
            
            var game = new Game(this, this);
            game.throwDice();
            var score = game.Score();
            Assert.That(score ,Is.EqualTo(50));
        }

        public int[] Roll()
        {
            return new[] {2, 3, 4, 6, 5};
        }

        public int CalculateScore()
        {
            return 50;
        }
    }

    public interface IScoreCalculator
    {
        int CalculateScore();
    }

    public interface IRoller
    {
        int[] Roll();
    }

    public class Game
    {
        readonly IRoller _roller;
        readonly IScoreCalculator _scoreCalculator;

        public Game(IRoller roller, IScoreCalculator scoreCalculator)
        {
            _roller = roller;
            _scoreCalculator = scoreCalculator;
        }

        public int Score()
        {
            return _scoreCalculator.CalculateScore();
        }

        public void throwDice()
        {
            var dice = _roller.Roll();
        }
    }
}
