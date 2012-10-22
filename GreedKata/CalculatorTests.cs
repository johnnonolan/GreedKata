using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class CalculatorTests : IDisplay
    {
        IScoreCalculator _greedDiceCalc;
        int _score;

        [SetUp]
        public void SetUp()
        {
            var scoringRules = new List<ScoringRule>
                                   {
                                       new ScoringRule {DieFace = 1, SingleScore = 100, TripleScore = 1000},
                                       new ScoringRule {DieFace = 5, SingleScore = 50, TripleScore = 500}
                                   };
            _greedDiceCalc = new GreedDiceCalc(scoringRules,this);
        }
        [Test]
        public void Single_5_and_no_other_scores_returns_50()
        {
            _greedDiceCalc.CalculateScore(new[]{2,3,4,6,5});
            Assert.That(_score, Is.EqualTo(50));
        }
            
        [Test]
        public void Single_1_and_no_other_scores_returns_100()
        {
            _greedDiceCalc.CalculateScore(new[] { 2, 3, 4, 6, 1 });
            Assert.That(_score, Is.EqualTo(100));              
        }

        [Test]
        public void No_scoring_dice()
        {
            _greedDiceCalc.CalculateScore(new[] { 2, 3, 4, 6, 6 });
            Assert.That(_score, Is.EqualTo(0));
        }

        [Test]
        public void Double_1_scores_200()
        {
            _greedDiceCalc.CalculateScore(new[] { 1, 3, 1, 6, 6 });
            Assert.That(_score, Is.EqualTo(200));
        }

        [Test]
        public void Double_5_and_single_1_scores_200()
        {
            _greedDiceCalc.CalculateScore(new[] { 2, 3, 5, 1, 5 });
            Assert.That(_score, Is.EqualTo(200));
        }

        [Test]
        public void Triple_1_scores_1000()
        {
            _greedDiceCalc.CalculateScore(new[] { 1, 3, 1, 1, 6 });
            Assert.That(_score, Is.EqualTo(1000));
            
        }

        public void Display(int score)
        {
            _score = score;
        }
    }
}
