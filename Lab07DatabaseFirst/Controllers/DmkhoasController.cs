using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab07DatabaseFirst.Models;

namespace Lab07DatabaseFirst.Controllers
{
    public class DmkhoasController : Controller
    {
        private readonly QLSinhVienContext _context;

        public DmkhoasController(QLSinhVienContext context)
        {
            _context = context;
        }

        // GET: Dmkhoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dmkhoas.ToListAsync());
        }

        // GET: Dmkhoas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dmkhoa = await _context.Dmkhoas
                .FirstOrDefaultAsync(m => m.MaKhoa == id);
            if (dmkhoa == null)
            {
                return NotFound();
            }

            return View(dmkhoa);
        }

        // GET: Dmkhoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dmkhoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhoa,TenKhoa")] Dmkhoa dmkhoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dmkhoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dmkhoa);
        }

        // GET: Dmkhoas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dmkhoa = await _context.Dmkhoas.FindAsync(id);
            if (dmkhoa == null)
            {
                return NotFound();
            }
            return View(dmkhoa);
        }

        // POST: Dmkhoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKhoa,TenKhoa")] Dmkhoa dmkhoa)
        {
            if (id != dmkhoa.MaKhoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dmkhoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DmkhoaExists(dmkhoa.MaKhoa))
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
            return View(dmkhoa);
        }

        // GET: Dmkhoas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dmkhoa = await _context.Dmkhoas
                .FirstOrDefaultAsync(m => m.MaKhoa == id);
            if (dmkhoa == null)
            {
                return NotFound();
            }

            return View(dmkhoa);
        }

        // POST: Dmkhoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dmkhoa = await _context.Dmkhoas.FindAsync(id);
            if (dmkhoa != null)
            {
                _context.Dmkhoas.Remove(dmkhoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DmkhoaExists(string id)
        {
            return _context.Dmkhoas.Any(e => e.MaKhoa == id);
        }
    }
}
