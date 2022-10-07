using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestViewModel : IValidatableObject
    {
        [Required]
        [Display(Name ="Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]

        public DateTime? StartTime { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]

        public DateTime? EndTime { get; set; }

        [Required]
        public int LeaveTypeId { get; set; }

        [Display(Name = "Leave Type")]
        public SelectList? LeaveTypes { get; set; }

        [Display(Name ="Request Comments")]
        public string? RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartTime > EndTime)
            {
                yield return new ValidationResult(StringConstants.START_DATE_GREATER_ERROR, new[] { nameof(StartTime), nameof(EndTime) });
            }
        }
    }
}
