using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Data.Employee;
using LeaveManagement.Web.IRepository;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<Employee> _userManager;

        private readonly ILeaveTypesRepository _leaveTypesRepository;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;
        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<Employee> userManager, ILeaveTypesRepository leaveTypesRepository, IMapper mapper, AutoMapper.IConfigurationProvider configurationProvider, IEmailSender emailSender) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypesRepository = leaveTypesRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
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
                                   .Where(entry => entry.EmployeeId == employeeId)
                                   .ProjectTo<LeaveAllocationViewModel>(_configurationProvider)                               
                                   .ToListAsync();

            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationVM = _mapper.Map<EmployeeAllocationViewModel>(employee);
            employeeAllocationVM.LeaveAllocations = allocations;
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

            var employeesWithNewAllocations = new List<Employee>();
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

                employeesWithNewAllocations.Add(employee);

            }

          int count =   await AddRangeAsync(allocations);

            foreach (var employee in employeesWithNewAllocations)
            {  
                await _emailSender.SendEmailAsync(employee.Email, $"Leave Allocation Posted for {period}", $"Your {leaveType.Name} leave" + 
                    $"has been posted for the period of {period}. You have been given {leaveType.DefaultDays}");
            }

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
