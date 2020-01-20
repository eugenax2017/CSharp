using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoSuperGuay.Lib.Context;
using DemoSuperGuay.Lib.Models;

namespace DemoSuperGuay.Controllers
{
    public class LendsController : Controller
    {
        private readonly DemoSuperGuayDbContext _context;

        public LendsController(DemoSuperGuayDbContext context)
        {
            _context = context;
        }

        // GET: Lends
        public async Task<IActionResult> Index()
        {
            var demoSuperGuayDbContext = _context.Lends.Include(l => l.Book).Include(l => l.Member);
            return View(await demoSuperGuayDbContext.ToListAsync());
        }

        // GET: Lends/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lends
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lend == null)
            {
                return NotFound();
            }

            return View(lend);
        }

        // GET: Lends/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            return View();
        }

        // POST: Lends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IsReturned,RequestedOn,ReturnedOn,MemberId,BookId,Id")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                lend.Id = Guid.NewGuid();
                _context.Add(lend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", lend.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", lend.MemberId);
            return View(lend);
        }

        // GET: Lends/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lends.FindAsync(id);
            if (lend == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", lend.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", lend.MemberId);
            return View(lend);
        }

        // POST: Lends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IsReturned,RequestedOn,ReturnedOn,MemberId,BookId,Id")] Lend lend)
        {
            if (id != lend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendExists(lend.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", lend.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", lend.MemberId);
            return View(lend);
        }

        // GET: Lends/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lends
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lend == null)
            {
                return NotFound();
            }

            return View(lend);
        }

        // POST: Lends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lend = await _context.Lends.FindAsync(id);
            _context.Lends.Remove(lend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendExists(Guid id)
        {
            return _context.Lends.Any(e => e.Id == id);
        }
    }
}
