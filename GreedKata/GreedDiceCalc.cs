using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedKata
{
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
}