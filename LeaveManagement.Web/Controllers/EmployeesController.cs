using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Data.Employee;
using LeaveManagement.Web.IRepository;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypesRepository _leaveTypesRepository;

        public EmployeesController( UserManager<Employee> userManager, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypesRepository leaveTypesRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypesRepository = leaveTypesRepository;
        }
        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(StringConstants.USER_ROLE);
            var model =  _mapper.Map<List<EmployeeListViewModel>>(employees);
            return View(model);
        }

        // GET: EmployeesController/ViewAllocation/5
        public async Task<IActionResult> ViewAllocation(string id)
        {
          var employeeAllocation =    await _leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(employeeAllocation);
        }

      

        // GET: EmployeesController/EditAllocation/5
        public async Task<IActionResult> EditAllocation(int id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocation(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(int id, LeaveAllocationEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && await _leaveAllocationRepository.UpdateEmployeeAllocation(model))               
                {
                      return RedirectToAction(nameof(ViewAllocation), new {id = model.EmployeeId});
                }
            }
            catch(Exception ex )
            {
                ModelState.AddModelError(string.Empty, $"An Error has Occurred i.e {ex.Message}. Please Try Again Lated");
            }

            model.Employee = _mapper.Map<EmployeeListViewModel>(await _userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = _mapper.Map<LeaveTypeViewModel>(await _leaveTypesRepository.GetAsync(model.LeaveTypeId));
            return View(model);

        }

      
    }
}
