using CandidateExpenses.Models;

namespace CandidateExpenses.Services
{
    public interface IExpenseCalculator
    {
        ExpenseStructure Calculate(decimal model);
    }
}