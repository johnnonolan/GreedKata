using System;
using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class ProvidedExamples : IScoreCalculator 
    {

        [Test]
        public void AreExamplesSatisfied()
        {
            var fakeRoller = new FakeRoller();
            fakeRoller.FakeRoll = () => new[] {1, 1, 1, 5, 1};
            var game = new Game(fakeRoller, this);
            game.ThrowDice();
            Assert.That(game.Score(),Is.EqualTo(1150));
            fakeRoller.FakeRoll = () => new[] { 2, 3, 4, 6, 2 };
            Assert.That(game.Score(), Is.EqualTo(0));
            fakeRoller.FakeRoll = () => new[] { 3, 4, 5, 3, 3 };
            Assert.That(game.Score(), Is.EqualTo(350));
            fakeRoller.FakeRoll = () => new[] { 1, 5, 1, 2, 4 };
            Assert.That(game.Score(), Is.EqualTo(250));
            fakeRoller.FakeRoll = () => new[] { 5, 5, 5, 5, 5 };
            Assert.That(game.Score(), Is.EqualTo(600));

        }

        public int CalculateScore(int[] lastDiceRoll)
        {
            //Note this has not been created and we are using SS
            throw new NotImplementedException();
        }
    }

    public class FakeRoller : IRoller
    {

        public delegate int[] RollFaker();

        public RollFaker FakeRoll;

        public int[] Roll()
        {
            return FakeRoll();
        }
    }
}
