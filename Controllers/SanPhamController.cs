using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TEST02.Models;

namespace TEST02.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly LTQLDBb _context;

        public SanPhamController(LTQLDBb context)
        {
            _context = context;
        }

        // GET: SanPham
        public async Task<IActionResult> Index()
        {
            var lTQLDBb = _context.SanPham.Include(s => s.NhaCungCap);
            return View(await lTQLDBb.ToListAsync());
        }

        // GET: SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaNhaCungCap == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPham/Create
        public IActionResult Create()
        {
            ViewData["MaNhaCungCap"] = new SelectList(_context.NhaCungCap, "MaNhaCungCap", "MaNhaCungCap");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhaCungCap,MaSanPham,TenSanPham")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNhaCungCap"] = new SelectList(_context.NhaCungCap, "MaNhaCungCap", "MaNhaCungCap", sanPham.MaNhaCungCap);
            return View(sanPham);
        }

        // GET: SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["MaNhaCungCap"] = new SelectList(_context.NhaCungCap, "MaNhaCungCap", "MaNhaCungCap", sanPham.MaNhaCungCap);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNhaCungCap,MaSanPham,TenSanPham")] SanPham sanPham)
        {
            if (id != sanPham.MaNhaCungCap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.MaNhaCungCap))
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
            ViewData["MaNhaCungCap"] = new SelectList(_context.NhaCungCap, "MaNhaCungCap", "MaNhaCungCap", sanPham.MaNhaCungCap);
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaNhaCungCap == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SanPham == null)
            {
                return Problem("Entity set 'LTQLDBb.SanPham'  is null.");
            }
            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPham.Remove(sanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
          return (_context.SanPham?.Any(e => e.MaNhaCungCap == id)).GetValueOrDefault();
        }
    }
}
