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
    public class HabitacionesController : ControllerBase
    {
                private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        // GET: Lista todas las habitaciones
        [HttpGet("ListarHabitaciones")]
        public Task<List<Habitacion>> ListarHabitaciones()
        {
            return _businessSql.ListarHabitaciones();
        }

        // GET: Detalles de una habitacion
        [HttpGet("BuscarHabitacion/{id}")]
        public async Task<Habitacion> BuscarHabitacion(int id)
        {
            return _businessSql.BuscarHabitacion(id);
        }

        // POST: Crea una nueva oferta
        [HttpPost("CrearHabitacion")]
        public bool CrearHabitacion(int estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int idTipoHabitacion)
        {
            return _businessSql.CrearHabitacion(estadoHabitacion, numeroHabitacion, capacidadMaxima, idTipoHabitacion);
        }

        // PUT: Actualiza una oferta existente
        [HttpPut("EditarHabitacion")]
        public bool EditarHabitacion(int idHabitacion, int estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int idTipoHabitacion)
        {
            return _businessSql.EditarHabitacion(idHabitacion, estadoHabitacion,  numeroHabitacion,  capacidadMaxima, idTipoHabitacion);
        }

        //// DELETE: Elimina una oferta existente
        //[HttpDelete("EliminarOferta")]
        //public bool EliminarOferta(int id)
        //{
        //    return _businessSql.EliminarOferta(id);
        //}
    }
}
