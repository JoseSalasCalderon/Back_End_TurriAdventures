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
    public class TiposHabitacionesController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context;

        public TiposHabitacionesController(HotelTurriAdventuresContext context)
        {
            _context = context;
        }

        // GET: Lista todos los tipos de habitaciones
        [HttpGet("ListarTiposHabitaciones")]
        public async Task<IActionResult> ListarTiposHabitaciones()
        {
            var tipoHabitacions = await _context.TipoHabitacion
                .Include(t => t.IdOfertaNavigation)
                .Include(t => t.IdTemporadaNavigation)
                .ToListAsync();

            return Ok(tipoHabitacions);
        }

        // GET: Detalles de un tipo de habitación específico
        [HttpGet("DetallesTipoHabitacion/{id}")]
        public async Task<IActionResult> DetallesTipoHabitacion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.TipoHabitacion
                .Include(t => t.IdOfertaNavigation)
                .Include(t => t.IdTemporadaNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoHabitacion == id);

            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return Ok(tipoHabitacion);
        }

        // POST: Crea un nuevo tipo de habitación
        [HttpPost("CrearTipoHabitacion")]
        public async Task<IActionResult> CrearTipoHabitacion(int idTipoHabitacion, string nombreTipoHabitacion, decimal precio, string descripcionTipoHabitacion, string imagenTipoHabitacion, int? idOferta, int? idTemporada)
        {
            if (ModelState.IsValid)
            {
                TipoHabitacion tipoHabitacion = new TipoHabitacion
                {
                    IdTipoHabitacion = idTipoHabitacion,
                    NombreTipoHabitacion = nombreTipoHabitacion,
                    Precio = precio,
                    DescripcionTipoHabitacion = descripcionTipoHabitacion,
                    ImagenTipoHabitacion = imagenTipoHabitacion,
                    IdOferta = idOferta,
                    IdTemporada = idTemporada
                };

                _context.Add(tipoHabitacion);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(DetallesTipoHabitacion), new { id = tipoHabitacion.IdTipoHabitacion }, tipoHabitacion);
            }
            return BadRequest(ModelState);
        }

        // PUT: Actualiza un tipo de habitación existente
        [HttpPut("EditarTipoHabitacion/{id}")]
        public async Task<IActionResult> EditarTipoHabitacion(int id, int idTipoHabitacion, string nombreTipoHabitacion, decimal precio, string descripcionTipoHabitacion, string imagenTipoHabitacion, int? idOferta, int? idTemporada)
        {
            if (id != idTipoHabitacion)
            {
                return BadRequest();
            }

            var tipoHabitacion = await _context.TipoHabitacion.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            tipoHabitacion.NombreTipoHabitacion = nombreTipoHabitacion;
            tipoHabitacion.Precio = precio;
            tipoHabitacion.DescripcionTipoHabitacion = descripcionTipoHabitacion;
            tipoHabitacion.ImagenTipoHabitacion = imagenTipoHabitacion;
            tipoHabitacion.IdOferta = idOferta;
            tipoHabitacion.IdTemporada = idTemporada;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoHabitacionExists(tipoHabitacion.IdTipoHabitacion))
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

        // DELETE: Elimina un tipo de habitación existente
        [HttpDelete("EliminarTipoHabitacion/{id}")]
        public async Task<IActionResult> EliminarTipoHabitacion(int id)
        {
            var tipoHabitacion = await _context.TipoHabitacion.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            _context.TipoHabitacion.Remove(tipoHabitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoHabitacionExists(int id)
        {
            return _context.TipoHabitacion.Any(e => e.IdTipoHabitacion == id);
        }
    }
}
