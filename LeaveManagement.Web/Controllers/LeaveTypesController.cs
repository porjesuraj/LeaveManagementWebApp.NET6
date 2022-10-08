using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.IRepository;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Common.Constants;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles=StringConstants.ADMIN_ROLE)]
    public class LeaveTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypesRepository _leaveTypesRepository;

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public LeaveTypesController(ILeaveTypesRepository leaveTypesRepository, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _mapper = mapper;
            _leaveTypesRepository = leaveTypesRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
           
            if (_leaveTypesRepository.LeaveTableExist())
            {

              var  leavesTypesVM = _mapper.Map<List<LeaveTypeViewModel>>(await _leaveTypesRepository.GetAllAsnyc());
                return View(leavesTypesVM);

            }
            return View();
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var leaveType = await _leaveTypesRepository.GetAsync(id);           
            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeVM = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DefaultDays,Id")] LeaveTypeViewModel leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);

                   await  _leaveTypesRepository.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           

            var leaveType = await _leaveTypesRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVM = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,DefaultDays,Id")] LeaveTypeViewModel leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = await _leaveTypesRepository.GetAsync(id);

                    if (leaveType == null)
                        return NotFound();


                     _mapper.Map(leaveTypeVM,leaveType);

                   await _leaveTypesRepository.UpdateAsync(id, leaveType);                
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! (await _leaveTypesRepository.ExistAsync(leaveTypeVM.Id)))
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
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
          

            var leaveType = await _leaveTypesRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVM = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_leaveTypesRepository.LeaveTableExist())
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            }
           
            await  _leaveTypesRepository.DeleteAsync(id);          
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("AllocateLeave")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AllocateLeave(int id)
        {
            await _leaveAllocationRepository.LeaveAllocation(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
