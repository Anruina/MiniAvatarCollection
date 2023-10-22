using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniAvatarCollection.Data;
using MiniAvatarCollection.Models;
using MiniAvatarCollectionLibrary;

namespace MiniAvatarCollection.Controllers
{
    public class CollectablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollectablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Collectables
        public async Task<IActionResult> Index()
        {
              return _context.collectables != null ? 
                          View(await _context.collectables.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.collectables'  is null.");
        }

        // GET: Collectables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.collectables == null)
            {
                return NotFound();
            }

            var collectable = await _context.collectables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectable == null)
            {
                return NotFound();
            }

            return View(collectable);
        }

        // GET: Collectables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collectables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Title,Nation")] Collectable collectable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collectable);
        }

        // GET: Collectables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.collectables == null)
            {
                return NotFound();
            }

            var collectable = await _context.collectables.FindAsync(id);
            if (collectable == null)
            {
                return NotFound();
            }
            return View(collectable);
        }

        // POST: Collectables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Nation")] Collectable collectable)
        {
            if (id != collectable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collectable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectableExists(collectable.Id))
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
            return View(collectable);
        }

        // GET: Collectables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.collectables == null)
            {
                return NotFound();
            }

            var collectable = await _context.collectables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectable == null)
            {
                return NotFound();
            }

            return View(collectable);
        }

        // POST: Collectables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.collectables == null)
            {
                return Problem("Entity set 'ApplicationDbContext.collectables'  is null.");
            }
            var collectable = await _context.collectables.FindAsync(id);
            if (collectable != null)
            {
                _context.collectables.Remove(collectable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectableExists(int id)
        {
          return (_context.collectables?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        // Select Nation during CREATE
    }
}
