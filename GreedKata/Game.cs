namespace GreedKata
{
    public class Game
    {
        readonly IRoller _roller;
        readonly IScoreCalculator _scoreCalculator;
        int[] _lastDiceRoll;

        public Game(IRoller roller, IScoreCalculator scoreCalculator)
        {
            _roller = roller;
            _scoreCalculator = scoreCalculator;
        }

        public int Score()
        {
            return _scoreCalculator.CalculateScore(_lastDiceRoll);
        }

        public void ThrowDice()
        {
            _lastDiceRoll = _roller.Roll();
        }
    }
}