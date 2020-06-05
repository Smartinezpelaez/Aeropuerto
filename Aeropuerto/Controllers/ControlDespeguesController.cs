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
    public class ControlDespeguesController : Controller
    {
        private readonly AeroContext _context;

        public ControlDespeguesController(AeroContext context)
        {
            _context = context;
        }

        // GET: ControlDespegues
        public async Task<IActionResult> Index()
        {
            return View(await _context.ControlDespegue.ToListAsync());
        }

        public async Task<IActionResult> IndexJson()
        {
            var aviancaContext = _context.ControlDespegue

               .Select(x => new {

                   id = x.Id,
                   idDespegue = x.IdDespegue,
                   pista = x.Pista,
                   estado = x.Estado,
                   clima = x.Clima,  
                   fecha = x.FechayHora,
                   aeropuerto = "Alfonso Bonilla"
               });
            return Json(await aviancaContext.ToListAsync());
        }
        // GET: ControlDespegues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlDespegue = await _context.ControlDespegue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlDespegue == null)
            {
                return NotFound();
            }

            return View(controlDespegue);
        }

        // GET: ControlDespegues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControlDespegues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdDespegue,Pista,Estado,Clima,Aeropuerto,FechayHora")] ControlDespegue controlDespegue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controlDespegue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controlDespegue);
        }

        // GET: ControlDespegues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlDespegue = await _context.ControlDespegue.FindAsync(id);
            if (controlDespegue == null)
            {
                return NotFound();
            }
            return View(controlDespegue);
        }

        // POST: ControlDespegues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdDespegue,Pista,Estado,Clima,Aeropuerto,FechayHora")] ControlDespegue controlDespegue)
        {
            if (id != controlDespegue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlDespegue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlDespegueExists(controlDespegue.Id))
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
            return View(controlDespegue);
        }

        // GET: ControlDespegues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlDespegue = await _context.ControlDespegue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlDespegue == null)
            {
                return NotFound();
            }

            return View(controlDespegue);
        }

        // POST: ControlDespegues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controlDespegue = await _context.ControlDespegue.FindAsync(id);
            _context.ControlDespegue.Remove(controlDespegue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlDespegueExists(int id)
        {
            return _context.ControlDespegue.Any(e => e.Id == id);
        }
    }
}
