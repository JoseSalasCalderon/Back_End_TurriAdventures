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
    public class HabitacionesController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly HabitacionBusinessSql _businessSql = new HabitacionBusinessSql();

        [HttpGet("ListarHabitaciones")]
        public Task<List<Habitacion>> ListarHabitaciones()
        {
            return _businessSql.ListarHabitaciones();
        }

        [HttpGet("BuscarHabitacion/{id}")]
        public async Task<Habitacion> BuscarHabitacion(int id)
        {
            return _businessSql.BuscarHabitacion(id);
        }

        [HttpGet("BuscarHabitacionPorIdReserva/{id}")]
        public async Task<Habitacion> BuscarHabitacionPorIdReserva(int id)
        {
            return _businessSql.BuscarHabitacionPorIdReserva(id);
        }

        [HttpGet("ConsultarDisponibilidadHabitaciones")]
        public async Task<List<Habitacion>> ConsultarDisponibilidadHabitaciones(string fechaLlegada, string fechaSalida, int tipo_habitacion_id)
        {
            return _businessSql.ConsultarDisponibilidadHabitaciones(fechaLlegada, fechaSalida, tipo_habitacion_id);
        }

        [HttpPost("CrearHabitacion")]
        public bool CrearHabitacion(int estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int idTipoHabitacion)
        {
            return _businessSql.CrearHabitacion(estadoHabitacion, numeroHabitacion, capacidadMaxima, idTipoHabitacion);
        }

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
