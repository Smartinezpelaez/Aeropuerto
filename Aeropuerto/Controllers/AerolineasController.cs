using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aeropuerto.Models;
using Aeropuerto.Data;

namespace Aeropuerto.Controllers
{
    public class AerolineasController : Controller
    {
        private readonly AeroContext _context;

        public AerolineasController(AeroContext context)
        {
            _context = context;
        }

        // GET: Aerolineas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aerolineas.ToListAsync());
        }

        // GET: Aerolineas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerolineas = await _context.Aerolineas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aerolineas == null)
            {
                return NotFound();
            }

            return View(aerolineas);
        }

        // GET: Aerolineas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aerolineas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Nit,Telefono")] Aerolineas aerolineas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aerolineas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aerolineas);
        }

        // GET: Aerolineas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerolineas = await _context.Aerolineas.FindAsync(id);
            if (aerolineas == null)
            {
                return NotFound();
            }
            return View(aerolineas);
        }

        // POST: Aerolineas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nit,Telefono")] Aerolineas aerolineas)
        {
            if (id != aerolineas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aerolineas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AerolineasExists(aerolineas.Id))
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
            return View(aerolineas);
        }

        // GET: Aerolineas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aerolineas = await _context.Aerolineas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aerolineas == null)
            {
                return NotFound();
            }

            return View(aerolineas);
        }

        // POST: Aerolineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aerolineas = await _context.Aerolineas.FindAsync(id);
            _context.Aerolineas.Remove(aerolineas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AerolineasExists(int id)
        {
            return _context.Aerolineas.Any(e => e.Id == id);
        }
    }
}
