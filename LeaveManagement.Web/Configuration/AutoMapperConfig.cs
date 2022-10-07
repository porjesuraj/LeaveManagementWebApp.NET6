using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Data.Employee;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Configuration
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
            CreateMap<Employee,EmployeeListViewModel>().ReverseMap();
            CreateMap<Employee,EmployeeAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationEditViewModel>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestViewModel>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestForEmployeeViewModel>().ReverseMap();
            CreateMap<LeaveRequest, AdminLeaveRequestViewViewModel>().ReverseMap();

           


        }
    }
}
