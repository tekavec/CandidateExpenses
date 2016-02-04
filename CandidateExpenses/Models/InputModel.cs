using System.ComponentModel.DataAnnotations;

namespace CandidateExpenses.Models
{
    public class InputModel
    {
        private const decimal DefaultValue = 0.01m;

        [Display(Name = "Input value:")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        [Range(0.01, 9998.00, ErrorMessage = "Valid input values are between 0.01 and 9998.00")]
        public decimal InputValue { get; set; } = DefaultValue;

    }
}