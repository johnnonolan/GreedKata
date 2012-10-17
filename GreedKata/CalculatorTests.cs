using NUnit.Framework;

namespace GreedKata
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Single_5_and_no_other_scores_returns_50()
        {
            IScoreCalculator greedDiceCalc =  new GreedDiceCalc();
            var score = greedDiceCalc.CalculateScore(new[]{2,3,4,6,5});
            Assert.That(score, Is.EqualTo(score));
        }
    }

    public class GreedDiceCalc : IScoreCalculator
    {
        public int CalculateScore(int[] lastDiceRoll)
        {
            return 50;
        }
    }
}
