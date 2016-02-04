namespace CandidateExpenses.Models
{
    public class ExpenseStructure
    {
        private readonly decimal _workingUnits;
        private readonly decimal _rate;

        public ExpenseStructure(decimal workingUnits, decimal rate)
        {
            _workingUnits = workingUnits;
            _rate = rate;
        }

        public decimal WorkingUnits => _workingUnits;
        public decimal Rate => _rate;

        protected bool Equals(ExpenseStructure other)
        {
            return _workingUnits == other._workingUnits && _rate == other._rate;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ExpenseStructure)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_workingUnits.GetHashCode() * 397) ^ _rate.GetHashCode();
            }
        }
    }
}