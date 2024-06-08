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
        private readonly TipoHabitacionBusinessSql _businessSql = new TipoHabitacionBusinessSql();

        [HttpGet("ListarTipoHabitaciones")]
        public Task<List<TipoHabitacion>> ListarTipoHabitaciones()
        {
            return _businessSql.ListarTipoHabitaciones();
        }

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

        [HttpPost("CrearTipoHabitacion")]
        public bool CrearTipoHabitacion(String nombreTipoHabitacion, decimal precio, String descripcionTipoHabitacion, String imagenTipoHabitacion, int idOferta, int idTemporada)
        {
            return _businessSql.CrearTipoHabitacion(nombreTipoHabitacion, precio, descripcionTipoHabitacion, imagenTipoHabitacion, idOferta, idTemporada);
        }

        [HttpPut("EditarTipoHabitacion")]
        public bool EditarTipoHabitacion(TipoHabitacion tipoHabitacion)
        {
            return _businessSql.EditarTipoHabitacion(tipoHabitacion);
        }

        //[HttpDelete("EliminarOferta")]
        //public bool EliminarOferta(int id)
        //{
        //    return _businessSql.EliminarOferta(id);
        //}
    }
}
