using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.IRepository
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {

        Task<bool> CreateLeaveRequest(LeaveRequestViewModel model);

        Task<EmployeeLeaveRequestViewModel> GetLeaveRequestDetails();

        Task<LeaveRequestForEmployeeViewModel> GetLeaveRequestAsync(int? id);
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);

        Task<AdminLeaveRequestViewViewModel> GetAdminLeaveRequestList();

        Task ChangeApprovalStatus(int leaveRequestId, bool approved);

        Task CancelLeaveRequest(int leaveRequestId);
    }
}
