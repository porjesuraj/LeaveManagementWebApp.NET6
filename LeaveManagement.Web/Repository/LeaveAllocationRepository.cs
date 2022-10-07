using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Data.Employee;
using LeaveManagement.Web.IRepository;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<Employee> _userManager;

        private readonly ILeaveTypesRepository _leaveTypesRepository;
        private readonly IMapper _mapper;
        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<Employee> userManager, ILeaveTypesRepository leaveTypesRepository, IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypesRepository = leaveTypesRepository;
            _mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            if(_context.LeaveAllocations != null)
               return await _context.LeaveAllocations.AnyAsync(entry => entry.EmployeeId == employeeId
                                                     && entry.LeaveTypeId == leaveTypeId
                                                     && entry.Period == period);

            return false;
        }

        public async Task<EmployeeAllocationViewModel> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _context.LeaveAllocations
                                   .Include(q => q.LeaveType)
                                   .Where(entry => entry.EmployeeId == employeeId).ToListAsync();

            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationVM = _mapper.Map<EmployeeAllocationViewModel>(employee);
            employeeAllocationVM.LeaveAllocations = _mapper.Map<List<LeaveAllocationViewModel>>(allocations);
            return employeeAllocationVM;
        }

        public async Task<LeaveAllocationEditViewModel> GetEmployeeAllocation(int id)
        {
            var allocation = await _context.LeaveAllocations
                                   .Include(q => q.LeaveType)
                                   .FirstOrDefaultAsync(entry => entry.Id == id);

            if(allocation == null)
            {
                return null;
            }
            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);
            var model = _mapper.Map<LeaveAllocationEditViewModel>(allocation);
            model.Employee = _mapper.Map<EmployeeListViewModel>(employee);

            return model;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(StringConstants.USER_ROLE);

            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypesRepository.GetAsync(leaveTypeId);

            var allocations = new List<LeaveAllocation>();
            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;

                    allocations.Add(new Data.LeaveAllocation
                    {
                        EmployeeId = employee.Id,
                        LeaveTypeId = leaveTypeId,
                        Period = period,
                        NumberOfDays = leaveType.DefaultDays
                    });
                
                

            }

          int count =   await AddRangeAsync(allocations);

            Console.WriteLine($"No of records added {count}");

        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditViewModel model)
        {

            var leaveAllocation = await GetAsync(model.Id);

            if (leaveAllocation == null)
            {
                return false;
            }

            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;

            await UpdateAsync(leaveAllocation.Id, leaveAllocation);

            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocationForLeaveId(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations
                                .Include(q => q.LeaveType)
                                .FirstOrDefaultAsync(entry => entry.EmployeeId == employeeId && entry.LeaveTypeId == leaveTypeId);


        }
    }
}
