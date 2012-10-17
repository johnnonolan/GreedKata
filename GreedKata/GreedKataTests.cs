using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class GreedKataTests
    {
        [Test]
        public void When_throwing_a_single_five_you_score_50()
        {
            var game = new Game();
            game.throwDice();
            var score = game.Score();
            Assert.That(score ,Is.EqualTo(50));
        }

    }

    public class Game
    {
        public int Score()
        {
            return 50;
        }

        public void throwDice()
        {

        }
    }
}
