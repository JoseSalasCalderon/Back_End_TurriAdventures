using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurriAdventures.Entities;

namespace TurriAdventures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HabitacionesController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context;

        public HabitacionesController(HotelTurriAdventuresContext context)
        {
            _context = context;
        }

        // GET: Lista todas las habitaciones
        [HttpGet("ListarHabitaciones")]
        public async Task<IActionResult> ListarHabitaciones()
        {
            var habitacions = await _context.Habitacion
                .Include(h => h.IdTipoHabitacionNavigation)
                .ToListAsync();

            return Ok(habitacions);
        }

        // GET: Detalles de una habitación específica
        [HttpGet("DetallesHabitacion/{id}")]
        public async Task<IActionResult> DetallesHabitacion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);

            if (habitacion == null)
            {
                return NotFound();
            }

            return Ok(habitacion);
        }

        // POST: Crea una nueva habitación
        [HttpPost("CrearHabitacion")]
        public async Task<IActionResult> CrearHabitacion(int idHabitacion, bool estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int? idTipoHabitacion)
        {
            if (ModelState.IsValid)
            {
                Habitacion habitacion = new Habitacion
                {
                    IdHabitacion = idHabitacion,
                    EstadoHabitacion = estadoHabitacion,
                    NumeroHabitacion = numeroHabitacion,
                    CapacidadMaxima = capacidadMaxima,
                    IdTipoHabitacion = idTipoHabitacion
                };

                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(DetallesHabitacion), new { id = habitacion.IdHabitacion }, habitacion);
            }
            return BadRequest(ModelState);
        }

        // PUT: Actualiza una habitación existente
        [HttpPut("EditarHabitacion/{id}")]
        public async Task<IActionResult> EditarHabitacion(int id, int idHabitacion, bool estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int? idTipoHabitacion)
        {
            if (id != idHabitacion)
            {
                return BadRequest();
            }

            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            habitacion.EstadoHabitacion = estadoHabitacion;
            habitacion.NumeroHabitacion = numeroHabitacion;
            habitacion.CapacidadMaxima = capacidadMaxima;
            habitacion.IdTipoHabitacion = idTipoHabitacion;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.IdHabitacion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: Elimina una habitación existente
        [HttpDelete("EliminarHabitacion/{id}")]
        public async Task<IActionResult> EliminarHabitacion(int id)
        {
            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            _context.Habitacion.Remove(habitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitacionExists(int id)
        {
            return _context.Habitacion.Any(e => e.IdHabitacion == id);
        }
    }
}
