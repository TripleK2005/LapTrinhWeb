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
    public class DssinhViensController : Controller
    {
        private readonly QLSinhVienContext _context;

        public DssinhViensController(QLSinhVienContext context)
        {
            _context = context;
        }

        // GET: DssinhViens
        public async Task<IActionResult> Index()
        {
            var qLSinhVienContext = _context.DssinhViens.Include(d => d.MaKhoaNavigation);
            return View(await qLSinhVienContext.ToListAsync());
        }

        // GET: DssinhViens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dssinhVien = await _context.DssinhViens
                .Include(d => d.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (dssinhVien == null)
            {
                return NotFound();
            }

            return View(dssinhVien);
        }

        // GET: DssinhViens/Create
        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Dmkhoas, "MaKhoa", "MaKhoa");
            return View();
        }

        // POST: DssinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSv,HoSv,TenSv,Phai,NgaySinh,NoiSinh,MaKhoa,HocBong")] DssinhVien dssinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dssinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Dmkhoas, "MaKhoa", "MaKhoa", dssinhVien.MaKhoa);
            return View(dssinhVien);
        }

        // GET: DssinhViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dssinhVien = await _context.DssinhViens.FindAsync(id);
            if (dssinhVien == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Dmkhoas, "MaKhoa", "MaKhoa", dssinhVien.MaKhoa);
            return View(dssinhVien);
        }

        // POST: DssinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSv,HoSv,TenSv,Phai,NgaySinh,NoiSinh,MaKhoa,HocBong")] DssinhVien dssinhVien)
        {
            if (id != dssinhVien.MaSv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dssinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DssinhVienExists(dssinhVien.MaSv))
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
            ViewData["MaKhoa"] = new SelectList(_context.Dmkhoas, "MaKhoa", "MaKhoa", dssinhVien.MaKhoa);
            return View(dssinhVien);
        }

        // GET: DssinhViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dssinhVien = await _context.DssinhViens
                .Include(d => d.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.MaSv == id);
            if (dssinhVien == null)
            {
                return NotFound();
            }

            return View(dssinhVien);
        }

        // POST: DssinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dssinhVien = await _context.DssinhViens.FindAsync(id);
            if (dssinhVien != null)
            {
                _context.DssinhViens.Remove(dssinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DssinhVienExists(string id)
        {
            return _context.DssinhViens.Any(e => e.MaSv == id);
        }
    }
}
