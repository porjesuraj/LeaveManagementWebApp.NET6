using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestForEmployeeViewModel : LeaveRequestViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        public LeaveTypeViewModel LeaveType { get; set; }

        [Display(Name = "Date Requested")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]

        public DateTime DateRequested { get; set; }

        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }


        public string? RequestingEmployeeId { get; set; }
        public EmployeeListViewModel RequestingEmployee { get; set; }


    }
}
