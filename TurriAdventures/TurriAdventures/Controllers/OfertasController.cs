using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurriAdventures.Entities;

namespace TurriAdventures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfertasController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        // GET: Lista todas las ofertas
        [HttpGet("ListarOfertas")]
        public Task<List<Oferta>> ListarOfertas()
        {
            return _businessSql.ListarOfertas();
        }

        // GET: Detalles de una oferta específica
        [HttpGet("DetallesOferta/{id}")]
        public async Task<IActionResult> DetallesOferta(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta.FirstOrDefaultAsync(m => m.IdOferta == id);
            if (oferta == null)
            {
                return NotFound();
            }

            return Ok(oferta);
        }

        // POST: Crea una nueva oferta
        [HttpPost("CrearOferta")]
        public async Task<IActionResult> CrearOferta(int idOferta, string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            if (ModelState.IsValid)
            {
                Oferta oferta = new Oferta
                {
                    IdOferta = idOferta,
                    DescripcionOferta = descripcionOferta,
                    FechaInicioOferta = fechaInicioOferta,
                    FechaFinalOferta = fechaFinalOferta,
                    PrecioOferta = precioOferta
                };

                _context.Add(oferta);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(DetallesOferta), new { id = oferta.IdOferta }, oferta);
            }
            return BadRequest(ModelState);
        }

        // PUT: Actualiza una oferta existente
        [HttpPut("EditarOferta/{id}")]
        public async Task<IActionResult> EditarOferta(int id, string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            var oferta = await _context.Oferta.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }

            oferta.DescripcionOferta = descripcionOferta;
            oferta.FechaInicioOferta = fechaInicioOferta;
            oferta.FechaFinalOferta = fechaFinalOferta;
            oferta.PrecioOferta = precioOferta;

            try
            {
                _context.Update(oferta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaExists(id))
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

        // DELETE: Elimina una oferta existente
        [HttpDelete("EliminarOferta/{id}")]
        public async Task<IActionResult> EliminarOferta(int id)
        {
            var oferta = await _context.Oferta.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }

            _context.Oferta.Remove(oferta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertaExists(int id)
        {
            return _context.Oferta.Any(e => e.IdOferta == id);
        }
    }
}
