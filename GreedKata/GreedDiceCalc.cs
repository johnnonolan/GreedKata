using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedKata
{
    public class GreedDiceCalc : IScoreCalculator
    {
        readonly IEnumerable<ScoringRule> _scoringRules;
        readonly IDisplay _display;

        public GreedDiceCalc(IEnumerable<ScoringRule> scoringRules, IDisplay display)
        {
            _scoringRules = scoringRules;
            _display = display;
        }

        public void CalculateScore(int[] lastDiceRoll)
        {
            int calculateScore = (from scoringRule in _scoringRules
                                  let scoringDice = ScoringDice(lastDiceRoll, scoringRule.DieFace)
                                  select scoringDice >= 3 ? scoringRule.TripleScore + (scoringRule.SingleScore*(scoringDice - 3)) : scoringRule.SingleScore*scoringDice).Sum();
            _display.Display( calculateScore);
        }

        static int ScoringDice(int[] lastDiceRoll, int scoringDice)
        {
            var findAll = Array.FindAll(lastDiceRoll, x => x == scoringDice);
            return findAll.Length;
        }
    }
}