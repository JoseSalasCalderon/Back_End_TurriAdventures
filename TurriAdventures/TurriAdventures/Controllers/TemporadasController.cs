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
        private readonly TemporadaBusinessSql _businessSql = new TemporadaBusinessSql();

        [HttpGet("ListarTemporadas")]
        public Task<List<Temporadum>> ListarTemporadas()
        {
            return _businessSql.ListarTemporadas();
        }

        [HttpGet("BuscarTemporada/{id}")]
        public async Task<Temporadum> BuscarTemporada(int id)
        {
            return _businessSql.BuscarTemporada(id);
        }

        [HttpPost("CrearTemporada")]
        public bool CrearTemporada(String descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            return _businessSql.CrearTemporada(descripcionTemporada, fechaInicioTemporada, fechaFinalTemporada, precioTemporada);
        }

        // PUT: Actualiza una oferta existente
        [HttpPut("EditarTemporada")]
        public bool EditarTemporada(int idTemporada, String descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            return _businessSql.EditarTemporada(idTemporada, descripcionTemporada, fechaInicioTemporada, fechaFinalTemporada, precioTemporada);
        }

        [HttpPost]
        [Route(nameof(eliminarTemporada))]
        public async Task<IActionResult> eliminarTemporada(int id)
        {
            _businessSql.eliminarTemporada(id);
            return NoContent();
        }
    }
}
