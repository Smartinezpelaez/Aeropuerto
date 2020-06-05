using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aeropuerto.Data;
using Aeropuerto.Models;

namespace Aeropuerto.Controllers
{
    public class ControlAterrizajesController : Controller
    {
        private readonly AeroContext _context;

        public ControlAterrizajesController(AeroContext context)
        {
            _context = context;
        }

        // GET: ControlAterrizajes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ControlAterrizaje.ToListAsync());
        }
        public async Task<IActionResult> IndexJson()
        {
            var aviancaContext = _context.ControlAterrizaje

               .Select(x => new {

                   id = x.Id,
                   idAterrizaje = x.IdAterrizaje,
                   pista = x.Pista,
                   estado = x.Estado,
                   clima = x.Clima,
                   fecha =x.FechayHora,
                   aeropuerto = "Alfonso Bonilla"
               });
            return Json(await aviancaContext.ToListAsync());
        }
        // GET: ControlAterrizajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlAterrizaje = await _context.ControlAterrizaje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlAterrizaje == null)
            {
                return NotFound();
            }

            return View(controlAterrizaje);
        }

        // GET: ControlAterrizajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControlAterrizajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAterrizaje,Pista,Estado,Clima,Aeropuerto,FechayHora")] ControlAterrizaje controlAterrizaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controlAterrizaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controlAterrizaje);
        }

        // GET: ControlAterrizajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlAterrizaje = await _context.ControlAterrizaje.FindAsync(id);
            if (controlAterrizaje == null)
            {
                return NotFound();
            }
            return View(controlAterrizaje);
        }

        // POST: ControlAterrizajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAterrizaje,Pista,Estado,Clima,Aeropuerto,FechayHora")] ControlAterrizaje controlAterrizaje)
        {
            if (id != controlAterrizaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlAterrizaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlAterrizajeExists(controlAterrizaje.Id))
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
            return View(controlAterrizaje);
        }

        // GET: ControlAterrizajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlAterrizaje = await _context.ControlAterrizaje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlAterrizaje == null)
            {
                return NotFound();
            }

            return View(controlAterrizaje);
        }

        // POST: ControlAterrizajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controlAterrizaje = await _context.ControlAterrizaje.FindAsync(id);
            _context.ControlAterrizaje.Remove(controlAterrizaje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlAterrizajeExists(int id)
        {
            return _context.ControlAterrizaje.Any(e => e.Id == id);
        }
    }
}
