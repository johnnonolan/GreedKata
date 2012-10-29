using Greed.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace GreedKata
{
    [TestFixture]
    public class ProvidedExamples : IDisplay
    {
        int _score;
        readonly FakeRoller _fakeRoller = new FakeRoller();
        GreedDiceCalc _scoreCalculator;

        readonly List<ScoringRule> _scoringRules = new List<ScoringRule>
                                 {
                                     new ScoringRule {DieFace = 1, SingleScore = 100, TripleScore = 1000},
                                     new ScoringRule {DieFace = 2, SingleScore = 0, TripleScore = 200},
                                     new ScoringRule {DieFace = 3, SingleScore = 0, TripleScore = 300},
                                     new ScoringRule {DieFace = 4, SingleScore = 0, TripleScore = 400},
                                     new ScoringRule {DieFace = 5, SingleScore = 50, TripleScore = 500},
                                     new ScoringRule {DieFace = 6, SingleScore = 0, TripleScore = 600}
                                 };

        [Test]
        public void AreExamplesSatisfied()
        {
            _scoreCalculator = new GreedDiceCalc(_scoringRules,this);
            var game = new Game(_fakeRoller, _scoreCalculator);
            Test1(game);
            Test2(game);
            Test3(game);
            Test4(game);           
            Test5(game);
        }

        void Test5(Game game)
        {
            _fakeRoller.FakeRoll = () => new[] {5, 5, 5, 5, 5};
            game.ThrowDice();

            Assert.That(_score, Is.EqualTo(600));
        }

        void Test4(Game game)
        {
            _fakeRoller.FakeRoll = () => new[] {1, 5, 1, 2, 4};
            game.ThrowDice();
            Assert.That(_score, Is.EqualTo(250));
        }

        void Test3(Game game)
        {
            _fakeRoller.FakeRoll = () => new[] {3, 4, 5, 3, 3};
            game.ThrowDice();
            Assert.That(_score, Is.EqualTo(350));
        }

        void Test2(Game game)
        {
            _fakeRoller.FakeRoll = () => new[] {2, 3, 4, 6, 2};
            game.ThrowDice();
            Assert.That(_score, Is.EqualTo(0));
        }

        void Test1(Game game)
        {
            _fakeRoller.FakeRoll = () => new[] {1, 1, 1, 5, 1};
            game.ThrowDice();
            Assert.That(_score, Is.EqualTo(1150));
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
