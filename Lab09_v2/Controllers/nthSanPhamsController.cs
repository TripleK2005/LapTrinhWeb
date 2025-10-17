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
    public class nthSanPhamsController : Controller
    {
        private readonly nthDbContext _context;

        public nthSanPhamsController(nthDbContext context)
        {
            _context = context;
        }

        // GET: nthSanPhams/nthIndex
        public async Task<IActionResult> nthIndex()
        {
            var nthDbContext = _context.nthSanPhams.Include(n => n.LoaiSanPham);
            return View(await nthDbContext.ToListAsync());
        }

        // GET: nthSanPhams/nthDetails/5
        public async Task<IActionResult> nthDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nthSanPham = await _context.nthSanPhams
                .Include(n => n.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.nthId == id);
            if (nthSanPham == null)
            {
                return NotFound();
            }

            return View(nthSanPham);
        }

        // GET: nthSanPhams/nthCreate
        public IActionResult nthCreate()
        {
            ViewData["nthLoaiId"] = new SelectList(_context.nthLoaiSanPhams, "nthId", "nthTenLoai");
            return View();
        }

        // POST: nthSanPhams/nthCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nthCreate(nthSanPham nthSanPham, IFormFile imageFile)
        {
            // Bỏ qua validation của trường Hình Ảnh vì ta sẽ xử lý nó thủ công
            ModelState.Remove("nthHinhAnh");

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // 1. Lấy đường dẫn đến thư mục lưu file (wwwroot/images)
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // 2. Tạo tên file duy nhất để tránh trùng lặp
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // 3. Lưu file vào thư mục
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    // 4. GÁN TÊN FILE VÀO MODEL - ĐÂY LÀ BƯỚC QUAN TRỌNG NHẤT
                    nthSanPham.nthHinhAnh = uniqueFileName;
                }
                else
                {
                    // Gán ảnh mặc định nếu người dùng không upload
                    // nthSanPham.nthHinhAnh = "default.png"; 

                    // Hoặc báo lỗi nếu ảnh là bắt buộc
                    ModelState.AddModelError("nthHinhAnh", "Vui lòng chọn hình ảnh sản phẩm.");
                    ViewData["nthLoaiId"] = new SelectList(_context.nthLoaiSanPhams, "nthId", "nthTenLoai", nthSanPham.nthLoaiId);
                    return View(nthSanPham);
                }

                _context.Add(nthSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(nthIndex));
            }

            // Nếu ModelState không hợp lệ, tạo lại SelectList và trả về View
            ViewData["nthLoaiId"] = new SelectList(_context.nthLoaiSanPhams, "nthId", "nthTenLoai", nthSanPham.nthLoaiId);
            return View(nthSanPham);
        }
        // GET: nthSanPhams/nthEdit/5
        public async Task<IActionResult> nthEdit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nthSanPham = await _context.nthSanPhams.FindAsync(id);
            if (nthSanPham == null)
            {
                return NotFound();
            }
            ViewData["nthLoaiId"] = new SelectList(_context.nthLoaiSanPhams, "nthId", "nthTenLoai", nthSanPham.nthLoaiId);
            return View(nthSanPham);
        }

        // POST: nthSanPhams/nthEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nthEdit(long id, [Bind("nthId,nthMaSanPham,nthTenSanPham,nthHinhAnh,nthSoLuong,nthDonGia,nthLoaiId")] nthSanPham nthSanPham)
        {
            if (id != nthSanPham.nthId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nthSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nthSanPhamExists(nthSanPham.nthId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Sửa RedirectToAction
                return RedirectToAction(nameof(nthIndex));
            }
            ViewData["nthLoaiId"] = new SelectList(_context.nthLoaiSanPhams, "nthId", "nthTenLoai", nthSanPham.nthLoaiId);
            return View(nthSanPham);
        }

        // GET: nthSanPhams/nthDelete/5
        public async Task<IActionResult> nthDelete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nthSanPham = await _context.nthSanPhams
                .Include(n => n.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.nthId == id);
            if (nthSanPham == null)
            {
                return NotFound();
            }

            return View(nthSanPham);
        }

        // POST: nthSanPhams/nthDelete/5
        // Sửa ActionName
        [HttpPost, ActionName("nthDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nthDeleteConfirmed(long id)
        {
            var nthSanPham = await _context.nthSanPhams.FindAsync(id);
            if (nthSanPham != null)
            {
                _context.nthSanPhams.Remove(nthSanPham);
            }

            await _context.SaveChangesAsync();
            // Sửa RedirectToAction
            return RedirectToAction(nameof(nthIndex));
        }

        private bool nthSanPhamExists(long id)
        {
            return _context.nthSanPhams.Any(e => e.nthId == id);
        }
    }
}