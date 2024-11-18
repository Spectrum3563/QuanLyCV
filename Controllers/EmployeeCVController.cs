using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCV.Data;
using QuanLyCV.Models;

namespace QuanLyCV.Controllers
{
    public class EmployeeCVController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeCVController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeCV
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeCVs.ToListAsync());
        }

        // GET: EmployeeCV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeCV = await _context.EmployeeCVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeCV == null)
            {
                return NotFound();
            }

            return View(employeeCV);
        }

        // GET: EmployeeCV/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeCV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Age,ProfilePicture,PhoneNumber,Degree,Certification")] EmployeeCV employeeCV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeCV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeCV);
        }

        // GET: EmployeeCV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeCV = await _context.EmployeeCVs.FindAsync(id);
            if (employeeCV == null)
            {
                return NotFound();
            }
            return View(employeeCV);
        }

        // POST: EmployeeCV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Age,ProfilePicture,PhoneNumber,Degree,Certification")] EmployeeCV employeeCV)
        {
            if (id != employeeCV.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeCV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeCVExists(employeeCV.Id))
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
            return View(employeeCV);
        }

        // GET: EmployeeCV/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeCV = await _context.EmployeeCVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeCV == null)
            {
                return NotFound();
            }

            return View(employeeCV);
        }

        // POST: EmployeeCV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeCV = await _context.EmployeeCVs.FindAsync(id);
            if (employeeCV != null)
            {
                _context.EmployeeCVs.Remove(employeeCV);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeCVExists(int id)
        {
            return _context.EmployeeCVs.Any(e => e.Id == id);
        }
    }
}
