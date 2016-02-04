using System;
using CandidateExpenses.Models;

namespace CandidateExpenses.Services
{
    public class MaximizeRateExpenseCalculator : IExpenseCalculator
    {
        private const decimal MaximumUnits = 99.99m;

        public ExpenseStructure Calculate(decimal inputValue)
        {
            return CalculateExpense(inputValue, 1m) ?? CalculateExpense(inputValue, 100m);
        }

        private ExpenseStructure CalculateExpense(decimal inputValue, decimal divisor)
        {
            for (var units = 1; units <= MaximumUnits * divisor; units++)
            {
                var rate = Math.Round(inputValue / (units / divisor), 2);
                if (rate <= MaximumUnits && Math.Round((units / divisor) * rate, 2) == inputValue)
                {
                    return new ExpenseStructure(units / divisor, rate);
                }
            }
            return null;
        }
    }
}