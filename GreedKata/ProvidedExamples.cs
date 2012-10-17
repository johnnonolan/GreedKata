using System;
using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class ProvidedExamples : IScoreCalculator 
    {
//        Examples
//• [1,1,1,5,1] = 1150 points
//• [2,3,4,6,2] = 0 points
//• [3,4,5,3,3] = 350 points
//• [1,5,1,2,4] = 250 points
//• [5,5,5,5,5] = 600 points
        [Test]
        public void AreExamplesSatisfied()
        {
            var fakeRoller = new FakeRoller();
            fakeRoller.FakeRoll = () => new[] {1, 1, 1, 5, 1};
            var game = new Game(fakeRoller, this);
            game.throwDice();
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

        public int CalculateScore()
        {
            //Note this has not been created and we are using SS
            throw new NotImplementedException();
        }
    }

    public class FakeRoller : IRoller
    {

        public delegate int[] RollFaker();

        public RollFaker FakeRoll = () => new int[5];

        public int[] Roll()
        {
            return FakeRoll();
        }
    }
}
