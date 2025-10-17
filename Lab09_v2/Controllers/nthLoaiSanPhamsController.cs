using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab09_v2.Models;

namespace Lab09_v2.Controllers
{
    public class nthLoaiSanPhamsController : Controller
    {
        private readonly nthDbContext _context;

        public nthLoaiSanPhamsController(nthDbContext context)
        {
            _context = context;
        }

        // GET: nthLoaiSanPhams/nthIndex
        public async Task<IActionResult> nthIndex()
        {
            return View(await _context.nthLoaiSanPhams.ToListAsync());
        }

        // GET: nthLoaiSanPhams/nthDetails/5
        public async Task<IActionResult> nthDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nthLoaiSanPham = await _context.nthLoaiSanPhams
                .FirstOrDefaultAsync(m => m.nthId == id);
            if (nthLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(nthLoaiSanPham);
        }

        // GET: nthLoaiSanPhams/nthCreate
        public IActionResult nthCreate()
        {
            return View();
        }

        // POST: nthLoaiSanPhams/nthCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nthCreate([Bind("nthId,nthMaLoai,nthTenLoai,nthTrangThai")] nthLoaiSanPham nthLoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nthLoaiSanPham);
                await _context.SaveChangesAsync();
                // Sửa RedirectToAction để trỏ về action mới
                return RedirectToAction(nameof(nthIndex));
            }
            return View(nthLoaiSanPham);
        }

        // GET: nthLoaiSanPhams/nthEdit/5
        public async Task<IActionResult> nthEdit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nthLoaiSanPham = await _context.nthLoaiSanPhams.FindAsync(id);
            if (nthLoaiSanPham == null)
            {
                return NotFound();
            }
            return View(nthLoaiSanPham);
        }

        // POST: nthLoaiSanPhams/nthEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nthEdit(long id, [Bind("nthId,nthMaLoai,nthTenLoai,nthTrangThai")] nthLoaiSanPham nthLoaiSanPham)
        {
            if (id != nthLoaiSanPham.nthId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nthLoaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nthLoaiSanPhamExists(nthLoaiSanPham.nthId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Sửa RedirectToAction để trỏ về action mới
                return RedirectToAction(nameof(nthIndex));
            }
            return View(nthLoaiSanPham);
        }

        // GET: nthLoaiSanPhams/nthDelete/5
        public async Task<IActionResult> nthDelete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nthLoaiSanPham = await _context.nthLoaiSanPhams
                .FirstOrDefaultAsync(m => m.nthId == id);
            if (nthLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(nthLoaiSanPham);
        }

        // POST: nthLoaiSanPhams/nthDelete/5
        // Sửa ActionName để khớp với action GET ở trên
        [HttpPost, ActionName("nthDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nthDeleteConfirmed(long id)
        {
            var nthLoaiSanPham = await _context.nthLoaiSanPhams.FindAsync(id);
            if (nthLoaiSanPham != null)
            {
                _context.nthLoaiSanPhams.Remove(nthLoaiSanPham);
            }

            await _context.SaveChangesAsync();
            // Sửa RedirectToAction để trỏ về action mới
            return RedirectToAction(nameof(nthIndex));
        }

        private bool nthLoaiSanPhamExists(long id)
        {
            return _context.nthLoaiSanPhams.Any(e => e.nthId == id);
        }
    }
}