using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class SelledBooksController : Controller
    {
        private readonly AppDbContext _context;

        public SelledBooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SelledBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.SelledBooks.ToListAsync());
        }

        // GET: SelledBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selledBook = await _context.SelledBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selledBook == null)
            {
                return NotFound();
            }

            return View(selledBook);
        }

        // GET: SelledBooks/Create
        public async Task<IActionResult> Create(int? id)
        {
            var book = await _context.Books.FindAsync(id);
            return View(book);
        }

        // POST: SelledBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookTitle,UserName,UserId,Quantity,OrderDate")] SelledBook selledBook)
        {
            selledBook.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(selledBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UserOrders));
            }
            return View(selledBook);
        }


        public async Task<IActionResult> UserOrders()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            return View(await _context.SelledBooks.Where(x=> x.UserId == id).ToListAsync());

        }

        // GET: SelledBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selledBook = await _context.SelledBooks.FindAsync(id);
            if (selledBook == null)
            {
                return NotFound();
            }
            return View(selledBook);
        }

        // POST: SelledBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookTitle,UserName,UserId,OrderDate")] SelledBook selledBook)
        {
            if (id != selledBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selledBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelledBookExists(selledBook.Id))
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
            return View(selledBook);
        }

        // GET: SelledBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selledBook = await _context.SelledBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selledBook == null)
            {
                return NotFound();
            }

            return View(selledBook);
        }

        // POST: SelledBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var selledBook = await _context.SelledBooks.FindAsync(id);
            if (selledBook != null)
            {
                _context.SelledBooks.Remove(selledBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelledBookExists(int id)
        {
            return _context.SelledBooks.Any(e => e.Id == id);
        }
    }
}
