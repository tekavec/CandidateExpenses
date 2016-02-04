using System;
using CandidateExpenses.Models;
using CandidateExpenses.Services;
using NUnit.Framework;

namespace CandidateExpenses.Tests.Services
{
    public class MaximizeRateExpenseCalculatorShould
    {
        [Test]
        public void calculate_1_working_unit_and_rate_equaling_expense_when_expense_is_less_than_100()
        {
            decimal inputValue = new Random().Next(9999) / 100m;

            var expenseStructure = new MaximizeRateExpenseCalculator().Calculate(inputValue);

            Assert.AreEqual(new ExpenseStructure(1m, inputValue, inputValue), expenseStructure);
        }

        [TestCase(100.00, 2.00, 50.00)]
        [TestCase(199.98, 2.00, 99.99)]
        [TestCase(9899.01, 99.00, 99.99)]
        public void calculate_smallest_wholenumber_working_unit_and_rate_when_expense_is_equal_or_greater_than_100(decimal inputValue, decimal workingUnit, decimal rate)
        {
            var expenseStructure = new MaximizeRateExpenseCalculator().Calculate(inputValue);

            Assert.AreEqual(new ExpenseStructure(workingUnit, rate, inputValue), expenseStructure);
        }

        [TestCase(7547.00, 76.14, 99.12)]
        [TestCase(9998.00, 99.99, 99.99)]
        [TestCase(100.07, 1.01, 99.08)]
        public void calculate_smallest_working_unit_and_rate_when_expense_is_equal_or_greater_than_100_and_working_unit_cannot_be_a_whole_number(decimal inputValue, decimal workingUnit, decimal rate)
        {
            var expenseStructure = new MaximizeRateExpenseCalculator().Calculate(inputValue);

            Assert.AreEqual(new ExpenseStructure(workingUnit, rate, inputValue), expenseStructure);
        }
    }
}