using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.IRepository
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {

        Task LeaveAllocation(int leaveTypeId);

        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);

        Task<EmployeeAllocationViewModel> GetEmployeeAllocations(string employeeId);
        Task<LeaveAllocation?> GetEmployeeAllocationForLeaveId(string employeeId, int leaveTypeId);
        Task<LeaveAllocationEditViewModel> GetEmployeeAllocation(int id);

        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditViewModel model);


    }
}
