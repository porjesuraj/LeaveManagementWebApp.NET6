using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Leave Type Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Default Number of Days")]
        [Range(1,20,ErrorMessage =$"Please Enter Valid day value i.e between 1-20")]
        public int DefaultDays { get; set; }

    }
}
