namespace LeaveManagement.Web.Models
{
    public class EmployeeLeaveRequestViewModel
    {

        public EmployeeLeaveRequestViewModel(List<LeaveAllocationViewModel> leaveAllocations, List<LeaveRequestForEmployeeViewModel> leaveRequest)
        {
            LeaveAllocations = leaveAllocations;
           LeaveRequest = leaveRequest;
        }

        public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }

        public List<LeaveRequestForEmployeeViewModel> LeaveRequest { get; set; }

    }
}
