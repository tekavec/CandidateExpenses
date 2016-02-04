using System.ComponentModel.DataAnnotations;

namespace CandidateExpenses.Models
{
    public class ExpenseStructure
    {
        private readonly decimal _workingUnits;
        private readonly decimal _rate;
        private readonly decimal _inputValue;

        public ExpenseStructure(decimal workingUnits, decimal rate, decimal inputValue)
        {
            _workingUnits = workingUnits;
            _rate = rate;
            _inputValue = inputValue;
        }

        [Display(Name = "Units")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal WorkingUnits => _workingUnits;

        [Display(Name = "Rate")]
        [DisplayFormat(DataFormatString = "£{0:0.00}")]
        public decimal Rate => _rate;

        [Display(Name = "Input value")]
        [DisplayFormat(DataFormatString = "£{0:0.00}")]
        public decimal InputValue => _inputValue;

        protected bool Equals(ExpenseStructure other)
        {
            return _workingUnits == other._workingUnits && _rate == other._rate && _inputValue == other._inputValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ExpenseStructure) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _workingUnits.GetHashCode();
                hashCode = (hashCode*397) ^ _rate.GetHashCode();
                hashCode = (hashCode*397) ^ _inputValue.GetHashCode();
                return hashCode;
            }
        }
    }
}