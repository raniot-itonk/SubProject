using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class CraftsmenController : Controller
    {
        // GET: Craftsmen1
        public async Task<IActionResult> Index()
        {
            const string httpsLocalhostApiCraftsmen = "https://localhost:5003/api/Craftsmen";
            var craftsmen = await httpsLocalhostApiCraftsmen.GetJsonAsync<List<Craftsman>>();
            return View(craftsmen);
        }

        //// GET: Craftsmen1/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var craftsman = await _context.Craftsmen
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (craftsman == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(craftsman);
        //}

        //// GET: Craftsmen1/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Craftsmen1/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,DateOfEmployment,LastName,SubjectArea,FirstName")] Craftsman craftsman)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(craftsman);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(craftsman);
        //}

        //// GET: Craftsmen1/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var craftsman = await _context.Craftsmen.FindAsync(id);
        //    if (craftsman == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(craftsman);
        //}

        //// POST: Craftsmen1/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("Id,DateOfEmployment,LastName,SubjectArea,FirstName")] Craftsman craftsman)
        //{
        //    if (id != craftsman.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(craftsman);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CraftsmanExists(craftsman.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(craftsman);
        //}

        //// GET: Craftsmen1/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var craftsman = await _context.Craftsmen
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (craftsman == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(craftsman);
        //}

        //// POST: Craftsmen1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var craftsman = await _context.Craftsmen.FindAsync(id);
        //    _context.Craftsmen.Remove(craftsman);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CraftsmanExists(long id)
        //{
        //    return _context.Craftsmen.Any(e => e.Id == id);
        //}
    }
}
