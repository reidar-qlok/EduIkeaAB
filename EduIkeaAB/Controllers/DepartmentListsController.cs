using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduIkeaAB.Data;
using EduIkeaAB.Models;

namespace EduIkeaAB.Controllers
{
    public class DepartmentListsController : Controller
    {
        private readonly IkeaDbContext _context;

        public DepartmentListsController(IkeaDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentLists
        public async Task<IActionResult> Index()
        {
            var ikeaDbContext = _context.DepartmentLists.Include(d => d.Department).Include(d => d.Employee);
            return View(await ikeaDbContext.ToListAsync());
        }

        // GET: DepartmentLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentList = await _context.DepartmentLists
                .Include(d => d.Department)
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentList == null)
            {
                return NotFound();
            }

            return View(departmentList);
        }

        // GET: DepartmentLists/Create
        public IActionResult Create()
        {
            ViewData["FkDepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: DepartmentLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FkEmployeeId,FkDepartmentId")] DepartmentList departmentList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkDepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", departmentList.FkDepartmentId);
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", departmentList.FkEmployeeId);
            return View(departmentList);
        }

        // GET: DepartmentLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentList = await _context.DepartmentLists.FindAsync(id);
            if (departmentList == null)
            {
                return NotFound();
            }
            ViewData["FkDepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", departmentList.FkDepartmentId);
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", departmentList.FkEmployeeId);
            return View(departmentList);
        }

        // POST: DepartmentLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FkEmployeeId,FkDepartmentId")] DepartmentList departmentList)
        {
            if (id != departmentList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentListExists(departmentList.Id))
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
            ViewData["FkDepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", departmentList.FkDepartmentId);
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", departmentList.FkEmployeeId);
            return View(departmentList);
        }

        // GET: DepartmentLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentList = await _context.DepartmentLists
                .Include(d => d.Department)
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentList == null)
            {
                return NotFound();
            }

            return View(departmentList);
        }

        // POST: DepartmentLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentList = await _context.DepartmentLists.FindAsync(id);
            if (departmentList != null)
            {
                _context.DepartmentLists.Remove(departmentList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentListExists(int id)
        {
            return _context.DepartmentLists.Any(e => e.Id == id);
        }
    }
}
