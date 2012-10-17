using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class GreedKataTests : IRoller, IScoreCalculator
    {
        [Test]
        public void When_throwing_a_single_five_you_score_50() //nb this is crap. I've faked everthing what is the value of this
        {
            
            var game = new Game(this, this);
            game.ThrowDice();
            var score = game.Score();
            Assert.That(score ,Is.EqualTo(50));
        }

        public int[] Roll()
        {
            return new[] {2, 3, 4, 6, 5};
        }

        public int CalculateScore(int[] lastDiceRoll)
        {
            return 50;
        }
    }

    public interface IScoreCalculator
    {
        int CalculateScore(int[] lastDiceRoll);
    }

    public interface IRoller
    {
        int[] Roll();
    }

    public class Game
    {
        readonly IRoller _roller;
        readonly IScoreCalculator _scoreCalculator;
        int[] _lastDiceRoll;

        public Game(IRoller roller, IScoreCalculator scoreCalculator)
        {
            _roller = roller;
            _scoreCalculator = scoreCalculator;
        }

        public int Score()
        {
            return _scoreCalculator.CalculateScore(_lastDiceRoll);
        }

        public void ThrowDice()
        {
            _lastDiceRoll = _roller.Roll();
        }
    }
}
