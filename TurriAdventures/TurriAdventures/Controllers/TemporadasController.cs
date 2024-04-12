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
    public class TemporadasController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context;

        public TemporadasController(HotelTurriAdventuresContext context)
        {
            _context = context;
        }

        // GET: Lista todas las temporadas
        [HttpGet("ListarTemporadas")]
        public async Task<IActionResult> ListarTemporadas()
        {
            var temporadas = await _context.Temporada.ToListAsync();
            return Ok(temporadas);
        }

        // GET: Detalles de una temporada específica
        [HttpGet("DetallesTemporada/{id}")]
        public async Task<IActionResult> DetallesTemporada(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporada = await _context.Temporada.FirstOrDefaultAsync(m => m.IdTemporada == id);
            if (temporada == null)
            {
                return NotFound();
            }

            return Ok(temporada);
        }

        // POST: Crea una nueva temporada
        [HttpPost("CrearTemporada")]
        public async Task<IActionResult> CrearTemporada(int idTemporada, string descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            if (ModelState.IsValid)
            {
                Temporada temporada = new Temporada
                {
                    IdTemporada = idTemporada,
                    DescripcionTemporada = descripcionTemporada,
                    FechaInicioTemporada = fechaInicioTemporada,
                    FechaFinalTemporada = fechaFinalTemporada,
                    PrecioTemporada = precioTemporada
                };

                _context.Add(temporada);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(DetallesTemporada), new { id = temporada.IdTemporada }, temporada);
            }
            return BadRequest(ModelState);
        }

        // PUT: Actualiza una temporada existente
        [HttpPut("EditarTemporada/{id}")]
        public async Task<IActionResult> EditarTemporada(int id, int idTemporada, string descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            if (id != idTemporada)
            {
                return BadRequest();
            }

            var temporada = await _context.Temporada.FindAsync(id);
            if (temporada == null)
            {
                return NotFound();
            }

            temporada.DescripcionTemporada = descripcionTemporada;
            temporada.FechaInicioTemporada = fechaInicioTemporada;
            temporada.FechaFinalTemporada = fechaFinalTemporada;
            temporada.PrecioTemporada = precioTemporada;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temporada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemporadaExists(temporada.IdTemporada))
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

        // DELETE: Elimina una temporada existente
        [HttpDelete("EliminarTemporada/{id}")]
        public async Task<IActionResult> EliminarTemporada(int id)
        {
            var temporada = await _context.Temporada.FindAsync(id);
            if (temporada == null)
            {
                return NotFound();
            }

            _context.Temporada.Remove(temporada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemporadaExists(int id)
        {
            return _context.Temporada.Any(e => e.IdTemporada == id);
        }
    }
}
