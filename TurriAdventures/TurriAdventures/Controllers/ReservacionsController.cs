using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Business.Business;

namespace TurriAdventures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservacionsController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        // GET: Lista todas las habitaciones
        [HttpGet("ListarReservas")]
        public Task<List<Reservacion>> ListarReservas()
        {
            return _businessSql.ListarReservas();
        }

        // GET: Detalles de una habitacion
        [HttpGet("BuscarReservaPorIdCliente/{id}")]
        public async Task<Reservacion> BuscarReservaPorIdCliente(String id)
        {
            return _businessSql.BuscarReservaPorIdCliente(id);
        }

        // POST: Crea una nueva oferta
        [HttpPost("CrearReserva")]
        public bool CrearReserva(Reservacion reservacion)
        {
            return _businessSql.CrearReserva(reservacion);
        }

        // PUT: Actualiza una oferta existente
        [HttpPut("modificarReserva")]
        public bool modificarReserva(Reservacion reservacion)
        {
            return _businessSql.modificarReserva(reservacion);
        }
    }
}
