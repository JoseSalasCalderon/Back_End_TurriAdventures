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
    public class TemporadasController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        [HttpGet("ListarTemporadas")]
        public Task<List<Temporada>> ListarTemporadas()
        {
            return _businessSql.ListarTemporadas();
        }

        [HttpGet("BuscarTemporada/{id}")]
        public async Task<Temporada> BuscarTemporada(int id)
        {
            return _businessSql.BuscarTemporada(id);
        }

        [HttpPost("CrearTemporada")]
        public bool CrearTemporada(String descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            return _businessSql.CrearTemporada(descripcionTemporada, fechaInicioTemporada, fechaFinalTemporada, precioTemporada);
        }

        // PUT: Actualiza una oferta existente
        [HttpPut("EditarOferta")]
        public bool EditarTemporada(int idTemporada, String descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            return _businessSql.EditarTemporada(idTemporada, descripcionTemporada, fechaInicioTemporada, fechaFinalTemporada, precioTemporada);
        }

        // DELETE: Elimina una oferta existente
        //[HttpDelete("EliminarOferta")]
        //public bool EliminarOferta(int id)
        //{
        //    return _businessSql.EliminarOferta(id);
        //}
    }
}
