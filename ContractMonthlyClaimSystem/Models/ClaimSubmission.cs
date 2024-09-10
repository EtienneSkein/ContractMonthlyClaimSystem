using System;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class ClaimSubmission
    {
        [Required]
        public DateTime ClaimDate { get; set; }

        [Required]
        [Range(1, 24, ErrorMessage = "Hours worked must be between 1 and 24.")]
        public int HoursWorked { get; set; }

        [Required]
        [Display(Name = "Supporting Document")]
        public string SupportingDocument { get; set; }
    }
}
