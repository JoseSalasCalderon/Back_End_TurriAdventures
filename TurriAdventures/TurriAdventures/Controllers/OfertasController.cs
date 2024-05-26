using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Business;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TurriAdventures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfertasController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly OfertaBusinessSql _businessSql = new OfertaBusinessSql();

        // GET: Lista todas las ofertas
        [HttpGet("ListarOfertas")]
        public Task<List<Ofertum>> ListarOfertas()
        {
            return _businessSql.ListarOfertas();
        }

        // GET: Detalles de una oferta específica
        [HttpGet("BuscarOferta/{id}")]
        public async Task<Ofertum> BuscarOferta(int id)
        {
            return _businessSql.BuscarOferta(id);
        }

        // POST: Crea una nueva oferta
        [HttpPost("CrearOferta")]
        public bool CrearOferta(string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            return _businessSql.CrearOferta(descripcionOferta, fechaInicioOferta, fechaFinalOferta, precioOferta);
        }

        // PUT: Actualiza una oferta existente
        [HttpPut("EditarOferta")]
        public bool EditarOferta(int idOferta, string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            return _businessSql.EditarOferta(idOferta, descripcionOferta, fechaInicioOferta, fechaFinalOferta, precioOferta);
        }

        // DELETE: Elimina una oferta existente
        [HttpDelete("EliminarOferta")]
        public bool EliminarOferta(int id)
        {
            return _businessSql.EliminarOferta(id);
        }

    }
}
