namespace CandidateExpenses.Models
{
    public class InputModel
    {
        private const decimal DefaultValue = 0.01m;

        public decimal Amount { get; set; } = DefaultValue;

    }
}