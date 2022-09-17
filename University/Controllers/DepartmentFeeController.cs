using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Data;

namespace University.Controllers
{
    public class DepartmentFeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentFeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentFee
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DepartmentFee.Include(d => d.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DepartmentFee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentFee == null)
            {
                return NotFound();
            }

            var departmentFee = await _context.DepartmentFee
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentFee == null)
            {
                return NotFound();
            }

            return View(departmentFee);
        }

        // GET: DepartmentFee/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: DepartmentFee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,DepartmentId")] DepartmentFee departmentFee)
        {
            if (ModelState.IsValid)
            {
                if (!_context.DepartmentFee.Any(df => df.DepartmentId == departmentFee.DepartmentId))
                {
                    _context.Add(departmentFee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", departmentFee.DepartmentId);
            return View(departmentFee);
        }

        // GET: DepartmentFee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentFee == null)
            {
                return NotFound();
            }

            var departmentFee = await _context.DepartmentFee.FindAsync(id);
            if (departmentFee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", departmentFee.DepartmentId);
            return View(departmentFee);
        }

        // POST: DepartmentFee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,DepartmentId")] DepartmentFee departmentFee)
        {
            if (id != departmentFee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentFeeExists(departmentFee.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", departmentFee.DepartmentId);
            return View(departmentFee);
        }

        // GET: DepartmentFee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentFee == null)
            {
                return NotFound();
            }

            var departmentFee = await _context.DepartmentFee
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentFee == null)
            {
                return NotFound();
            }

            return View(departmentFee);
        }

        // POST: DepartmentFee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentFee == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DepartmentFee'  is null.");
            }
            var departmentFee = await _context.DepartmentFee.FindAsync(id);
            if (departmentFee != null)
            {
                _context.DepartmentFee.Remove(departmentFee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentFeeExists(int id)
        {
          return _context.DepartmentFee.Any(e => e.Id == id);
        }
    }
}
