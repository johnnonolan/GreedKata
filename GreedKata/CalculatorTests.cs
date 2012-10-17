using System;
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
            _greedDiceCalc = new GreedDiceCalc();
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
        public int CalculateScore(int[] lastDiceRoll)
        {
            var score = 0;
            var num_1s = ScoringDice(lastDiceRoll, 1);
            var num_5s = ScoringDice(lastDiceRoll, 5);
            //duplication
            if (num_5s > 0)
                score += 50*num_5s;
            if (num_1s >0 )
                score+= 100*num_1s;
            return score;
        }

        static int ScoringDice(int[] lastDiceRoll, int scoringDice)
        {
            int[] findAll = Array.FindAll(lastDiceRoll, x => x == scoringDice);
            return findAll.Length;
        }
    }
}
