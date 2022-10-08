using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.IRepository;
using LeaveManagement.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILogger<LeaveRequestsController> _logger;
        public LeaveRequestsController(ApplicationDbContext context, ILeaveRequestRepository leaveRequestRepository, ILogger<LeaveRequestsController> logger)
        {
            _context = context;
            _leaveRequestRepository = leaveRequestRepository;
            _logger = logger;
        }

        public async Task<IActionResult> MyLeave()
        {
            var model = await _leaveRequestRepository.GetLeaveRequestDetails();
            return View(model);
        }


        [Authorize(Roles =StringConstants.ADMIN_ROLE)]
        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var leaves = await _leaveRequestRepository.GetAdminLeaveRequestList();
            if (leaves == null)
                return NotFound();

            return View(leaves);
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var model = await _leaveRequestRepository.GetLeaveRequestAsync(id);

            if (model == null)
                return NotFound();
           
            return View(model);
        }

        // POST: LeaveRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int Id, bool approved)
        {
            try
            {
              await  _leaveRequestRepository.ChangeApprovalStatus(Id, approved);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Approving Request");
                ModelState.AddModelError(string.Empty, StringConstants.GENERIC_ERROR_MESSAGE + ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            var model = new LeaveRequestViewModel
            {
                LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name")

            };
            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LeaveRequestViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                  var IsValidRequest =   await _leaveRequestRepository.CreateLeaveRequest(model);

                    if(IsValidRequest)
                    {
                        return RedirectToAction(nameof(MyLeave));

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, StringConstants.INVALID_LEAVE_REQUEST_ERROR_MESSAGE);

                    }

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Leave Request");

                ModelState.AddModelError(string.Empty, StringConstants.GENERIC_ERROR_MESSAGE);
                
            }
           
            model.LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name", model.LeaveTypeId);
            return View(model);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartTime,EndTime,LeaveTypeId,DateRequested,RequestComments,Approved,Cancelled,RequestingEmployeeId,Id,DateCreated,DateModified")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

     

        // POST: LeaveRequests/CancelRequest/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelRequest(int id)
        {
            if (_context.LeaveRequests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveRequests'  is null.");
            }

            await _leaveRequestRepository.CancelLeaveRequest(id);
            return RedirectToAction(nameof(MyLeave));
        }




        private bool LeaveRequestExists(int id)
        {
          return _context.LeaveRequests.Any(e => e.Id == id);
        }
    }
}
