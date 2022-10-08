using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Common.Constants;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Data.Employee;
using LeaveManagement.Web.IRepository;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly AutoMapper.IConfigurationProvider _configuration;
        private readonly IEmailSender _emailSender; 
        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<Employee> userManager, ILeaveAllocationRepository leaveAllocationRepository, AutoMapper.IConfigurationProvider configuration, IEmailSender emailSender) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _leaveAllocationRepository = leaveAllocationRepository;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);

            leaveRequest.Cancelled = true;

            await UpdateAsync(leaveRequestId, leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var approvalStatus = "Cancelled";

            await _emailSender.SendEmailAsync(user.Email, $"Leave Request {approvalStatus}", string.Format(StringConstants.EMAIL_BODY_FOR_LEAVE_REQUEST_CHANGED, leaveRequest.StartTime, leaveRequest.EndTime, approvalStatus));

        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);

            leaveRequest.Approved = approved;

           
            if(approved)
            {
                var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocationForLeaveId(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

                int dayRequested = (int)(leaveRequest.EndTime - leaveRequest.StartTime).TotalDays;

                leaveAllocation.NumberOfDays -= dayRequested;


            }

            await UpdateAsync(leaveRequest.Id,leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var approvalStatus = approved ? "Approved" : "Declined";

            await _emailSender.SendEmailAsync(user.Email, $"Leave Request {approvalStatus}" , string.Format(StringConstants.EMAIL_BODY_FOR_LEAVE_REQUEST_CHANGED, leaveRequest.StartTime, leaveRequest.EndTime, approvalStatus));

        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestViewModel model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocationForLeaveId(user.Id, model.LeaveTypeId);

            if (leaveAllocation == null)
                return false;

            int daysRequested = (int)(model.EndTime.Value - model.StartTime.Value).TotalDays;

            if(daysRequested> leaveAllocation?.NumberOfDays)
            {
                return false;
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            

            await AddAsync(leaveRequest);
 
            await _emailSender.SendEmailAsync(user.Email, StringConstants.EMAIL_SUBJECT_FOR_LEAVE_SUCCESS,string.Format(StringConstants.EMAIL_BODY_FOR_LEAVE_SUCCESS, leaveRequest.StartTime, leaveRequest.EndTime));

            return true;

        }

        public async Task<AdminLeaveRequestViewViewModel> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _context.LeaveRequests.
                                      Include(q => q.LeaveType).
                                      ProjectTo<LeaveRequestForEmployeeViewModel>(_configuration).
                                      ToListAsync();


            var model = new AdminLeaveRequestViewViewModel
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = leaveRequests

            };

            foreach (var leaveRequest in model.LeaveRequests)
            {

                leaveRequest.RequestingEmployee =  _mapper.Map<EmployeeListViewModel>( await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }


            return model;
        }

        public async Task<List<LeaveRequestForEmployeeViewModel>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests
                                 .Where(e => e.RequestingEmployeeId == employeeId)
                                 .ProjectTo<LeaveRequestForEmployeeViewModel>(_configuration)
                                 .ToListAsync();

                
        }

        public async Task<LeaveRequestForEmployeeViewModel> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests
                                     .Include(q => q.LeaveType)
                                     .FirstOrDefaultAsync(q => q.Id == id);

            if (leaveRequest == null)
            {
                return null;
            }
            var model = _mapper.Map<LeaveRequestForEmployeeViewModel>(leaveRequest);

            model.RequestingEmployee = _mapper.Map<EmployeeListViewModel>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
            return model;

        }

        public async Task<EmployeeLeaveRequestViewModel> GetLeaveRequestDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            var allocation = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;

            var leaveRequest = await GetAllAsync(user.Id);

            var model = new EmployeeLeaveRequestViewModel(allocation,leaveRequest);
                     
            return model;
        }
    }
}
