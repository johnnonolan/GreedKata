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
                                       new ScoringRule {DieFace = 1, SingleScore = 100, TripleScore = 1000},
                                       new ScoringRule {DieFace = 5, SingleScore = 50, TripleScore = 500}
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

        [Test]
        public void Triple_1_scores_1000()
        {
            var score = _greedDiceCalc.CalculateScore(new[] { 1, 3, 1, 1, 6 });
            Assert.That(score, Is.EqualTo(1000));
            
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
            return (from scoringRule in _scoringRules
                    let scoringDice = ScoringDice(lastDiceRoll, scoringRule.DieFace)
                    select scoringDice >= 3 ? scoringRule.TripleScore + (scoringRule.SingleScore*(scoringDice - 3)) : scoringRule.SingleScore*scoringDice).Sum();
        }

        static int ScoringDice(int[] lastDiceRoll, int scoringDice)
        {
            var findAll = Array.FindAll(lastDiceRoll, x => x == scoringDice);
            return findAll.Length;
        }
    }

    public class ScoringRule
    {
        public int DieFace { get; set; }
        public int SingleScore { get; set; }
        public int TripleScore { get; set; }
    }
}
