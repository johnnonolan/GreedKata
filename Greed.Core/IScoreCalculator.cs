namespace Greed.Core
{
    public interface IScoreCalculator
    {
        void CalculateScore(int[] lastDiceRoll);
    }
}