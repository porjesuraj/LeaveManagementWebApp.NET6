using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name ="Number Of Days")]
        [Required]
        [Range(1,20,ErrorMessage ="Entered Value is InValid, Range is between 1- 20")]
        public int NumberOfDays { get; set; }

        [Required]
        [Display(Name ="Allocation Period")]
        public int Period { get; set; }

        public LeaveTypeViewModel? LeaveType { get; set; }
    }
}