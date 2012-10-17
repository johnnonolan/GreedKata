using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class CalculatorTests
    {
        IScoreCalculator _greedDiceCalc;

        [SetUp]
        public void SetUp()
        {
            var scoringRules = new List<ScoringRule>
                                   {
                                       new ScoringRule {DiceFace = 1, SingleScore = 100},
                                       new ScoringRule {DiceFace = 5, SingleScore = 50}
                                   };
            _greedDiceCalc = new GreedDiceCalc(scoringRules);
        }
        [Test]
        public void Single_5_and_no_other_scores_returns_50()
        {
            var score = _greedDiceCalc.CalculateScore(new[]{2,3,4,6,5});
            Assert.That(score, Is.EqualTo(50));
        }
            
        [Test]
        public void Single_1_and_no_other_scores_returns_100()
        {
            var score = _greedDiceCalc.CalculateScore(new[] { 2, 3, 4, 6, 1 });
            Assert.That(score, Is.EqualTo(100));              
        }

        [Test]
        public void No_scoring_dice()
        {
            var score = _greedDiceCalc.CalculateScore(new[] { 2, 3, 4, 6, 6 });
            Assert.That(score, Is.EqualTo(0));
        }

        [Test]
        public void Double_1_scores_200()
        {
            var score = _greedDiceCalc.CalculateScore(new[] { 1, 3, 1, 6, 6 });
            Assert.That(score, Is.EqualTo(200));
        }

        [Test]
        public void Double_5_and_single_1_scores_200()
        {
            var score = _greedDiceCalc.CalculateScore(new[] { 2, 3, 5, 1, 5 });
            Assert.That(score, Is.EqualTo(200));
            
        }
    
    }

    public class GreedDiceCalc : IScoreCalculator
    {
        readonly IEnumerable<ScoringRule> _scoringRules;

        public GreedDiceCalc(IEnumerable<ScoringRule> scoringRules)
        {
            _scoringRules = scoringRules;
        }

        public int CalculateScore(int[] lastDiceRoll)
        {
            return _scoringRules.Sum(scoringRule => ScoringDice(lastDiceRoll, scoringRule.DiceFace)*scoringRule.SingleScore);
        }

        static int ScoringDice(int[] lastDiceRoll, int scoringDice)
        {
            var findAll = Array.FindAll(lastDiceRoll, x => x == scoringDice);
            return findAll.Length;
        }
    }

    public class ScoringRule
    {
        public int DiceFace { get; set; }
        public int SingleScore { get; set; }
    }
}
