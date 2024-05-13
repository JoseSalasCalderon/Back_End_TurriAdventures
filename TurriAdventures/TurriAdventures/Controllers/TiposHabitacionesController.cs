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
    public class TiposHabitacionesController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        // GET: Lista todas las ofertas
        [HttpGet("ListarTipoHabitaciones")]
        public Task<List<TipoHabitacion>> ListarTipoHabitaciones()
        {
            return _businessSql.ListarTipoHabitaciones();
        }

        // GET: Detalles de una oferta específica
        [HttpGet("BuscarTipoHabitacion/{id}")]
        public async Task<TipoHabitacion> BuscarTipoHabitacion(int id)
        {
            return _businessSql.BuscarTipoHabitacion(id);
        }

        [HttpGet("BuscarTipoHabitacionPorHabitacion/{id}")]
        public async Task<TipoHabitacion> BuscarTipoHabitacionPorHabitacion(int id)
        {
            return _businessSql.BuscarTipoHabitacionPorHabitacion(id);
        }

        // POST: Crea una nueva oferta
        [HttpPost("CrearTipoHabitacion")]
        public bool CrearTipoHabitacion(String nombreTipoHabitacion, decimal precio, String descripcionTipoHabitacion, String imagenTipoHabitacion, int idOferta, int idTemporada)
        {
            return _businessSql.CrearTipoHabitacion(nombreTipoHabitacion, precio, descripcionTipoHabitacion, imagenTipoHabitacion, idOferta, idTemporada);
        }

        // PUT: Actualiza una oferta existente
        [HttpPut("EditarTipoHabitacion")]
        public bool EditarTipoHabitacion(int idHabitacion, String nombreTipoHabitacion, decimal precio, String descripcionTipoHabitacion, String imagenTipoHabitacion, int idOferta, int idTemporada)
        {
            return _businessSql.EditarTipoHabitacion(idHabitacion, nombreTipoHabitacion, precio, descripcionTipoHabitacion, imagenTipoHabitacion, idOferta, idTemporada);
        }

        // DELETE: Elimina una oferta existente
        //[HttpDelete("EliminarOferta")]
        //public bool EliminarOferta(int id)
        //{
        //    return _businessSql.EliminarOferta(id);
        //}
    }
}
