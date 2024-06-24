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
        private readonly ReservacionBusinessSql _businessSql = new ReservacionBusinessSql();

        [HttpGet("ListarReservas")]
        public Task<List<Reservacion>> ListarReservas()
        {
            return _businessSql.ListarReservas();
        }

        [HttpGet("BuscarReservaPorIdCliente/{id}")]
        public async Task<Reservacion> BuscarReservaPorIdCliente(String id)
        {
            return _businessSql.BuscarReservaPorIdCliente(id);
        }

        [HttpGet("BuscarReservaPorId/{idReserva}")]
        public Reservacion BuscarReservaPorId(int idReserva)
        { 
            return _businessSql.BuscarReservaPorId(idReserva);
        }

            [HttpPost("CrearReserva")]
        public int CrearReserva(Reservacion reservacion)
        {
            return _businessSql.CrearReserva(reservacion);
        }

        [HttpPut("modificarReserva")]
        public bool modificarReserva(Reservacion reservacion)
        {
            return _businessSql.modificarReserva(reservacion);
        }

        [HttpDelete("EliminarReserva")]
        public bool EliminarReserva(int idReserva)
        {
            return _businessSql.EliminarReserva(idReserva);
        }
    }
}
