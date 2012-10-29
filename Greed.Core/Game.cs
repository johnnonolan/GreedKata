namespace Greed.Core
{
    public class Game
    {
        readonly IRoller _roller;
        readonly IScoreCalculator _scoreCalculator;

        public Game(IRoller roller, IScoreCalculator scoreCalculator)
        {
            _roller = roller;
            _scoreCalculator = scoreCalculator;
        }

        public void ThrowDice()
        {            
            _scoreCalculator.CalculateScore(_roller.Roll());
        }
    }
}