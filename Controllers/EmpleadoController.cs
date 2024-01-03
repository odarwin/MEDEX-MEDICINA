using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoMedexcard.Entities;
using ProyectoMedexcard.Models.Empleados;
using ProyectoMedexcard.Stores;

namespace ProyectoMedexcard.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IEmpleadoStore _empleadoStore;

        public EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
            _empleadoStore = new EmpleadoStore(_context);

        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Empleados.Include(e => e.Em_IdPersonaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.Em_IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.Em_Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/Create
        public IActionResult Create()
        {
            EmpleadoViewModel model = new EmpleadoViewModel();
            ViewBag.TiposEmpleados = new SelectList(new List<TipoEmpleado>
            {
                new TipoEmpleado { Id = 1, Descripcion = "Asesor" }
            }, "Id", "Descripcion");

            return View(model);
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hoy = DateTime.Now;
                Persona persona = new Persona { 
                    Per_Nombre=model.nombre,
                    Per_Apellido=model.apellido,
                    Per_Cedula=model.cedula,
                    Per_TipoIdentificacion="CI",
                    Per_FechaNacimiento=model.FechaNacimiento,
                    Per_FechaCreacion=hoy,
                    Per_Activo=true,
                    Per_Eliminado=false
                };

                var empleado = _empleadoStore.CreateAsync(persona);
       
            }
            return View(model);
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["Em_IdPersona"] = new SelectList(_context.Personas, "Per_Id", "Per_Id", empleado.Em_IdPersona);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Em_Id,Em_IdPersona,Em_FechaCreacion,Em_FechaModifica,Em_FechaElimina,Em_UsuCreacion,Em_UsuModifica,Em_UsuElimina,Em_Rol,Em_Activo,Em_Eliminado")] Empleado empleado)
        {
            if (id != empleado.Em_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Em_Id))
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
            ViewData["Em_IdPersona"] = new SelectList(_context.Personas, "Per_Id", "Per_Id", empleado.Em_IdPersona);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.Em_IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.Em_Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Empleados'  is null.");
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.Empleados?.Any(e => e.Em_Id == id)).GetValueOrDefault();
        }
    }
}
