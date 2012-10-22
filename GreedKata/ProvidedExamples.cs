using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace GreedKata
{
    [TestFixture]
    public class ProvidedExamples : IDisplay
    {
        int _score;

        [Test]
        public void AreExamplesSatisfied()
        {
            var scorerules = new List<ScoringRule>
                                   {
                                       new ScoringRule {DieFace = 1, SingleScore = 100, TripleScore = 1000},
                                       new ScoringRule {DieFace = 2, SingleScore = 0, TripleScore = 200},
                                       new ScoringRule {DieFace = 3, SingleScore = 0, TripleScore = 300},
                                       new ScoringRule {DieFace = 4, SingleScore = 0, TripleScore = 400},
                                       new ScoringRule {DieFace = 5, SingleScore = 50, TripleScore = 500},
                                       new ScoringRule {DieFace = 6, SingleScore = 0, TripleScore = 600}
                                   };
            var calc = new GreedDiceCalc(scorerules,this);
            var fakeRoller = new FakeRoller();
            fakeRoller.FakeRoll = () => new[] {1, 1, 1, 5, 1};
            var game = new Game(fakeRoller, calc);
            game.ThrowDice();
            game.Score();
            Assert.That(_score,Is.EqualTo(1150));
            fakeRoller.FakeRoll = () => new[] { 2, 3, 4, 6, 2 };
            game.ThrowDice();
            game.Score();
            Assert.That(_score, Is.EqualTo(0));
            fakeRoller.FakeRoll = () => new[] { 3, 4, 5, 3, 3 };
            game.ThrowDice();
            game.Score();
            Assert.That(_score, Is.EqualTo(350));
            fakeRoller.FakeRoll = () => new[] { 1, 5, 1, 2, 4 };
            game.ThrowDice();
            game.Score();
            Assert.That(_score, Is.EqualTo(250));
            game.ThrowDice();
            game.Score();
            fakeRoller.FakeRoll = () => new[] { 5, 5, 5, 5, 5 };
            game.ThrowDice();
            game.Score();
            Assert.That(_score, Is.EqualTo(600));
        }

        public void Display(int score)
        {
            _score = score;
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
