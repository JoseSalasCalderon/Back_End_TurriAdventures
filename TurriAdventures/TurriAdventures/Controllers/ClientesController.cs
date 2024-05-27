using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Business;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TurriAdventures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly ClienteBusinessSql _businessSql = new ClienteBusinessSql();

        [HttpGet("ListarClientes")]
        public Task<List<Cliente>> ListarClientes()
        {
            return _businessSql.ListarClientes();
        }

        [HttpGet("BuscarCliente/{id}")]
        public async Task<Cliente> BuscarCliente(String id)
        {
            return _businessSql.BuscarCliente(id);
        }

        [HttpGet("BuscarClientePorIdReservacion/{id}")]
        public async Task<Cliente> BuscarClientePorIdReservacion(int id)
        {
            return _businessSql.BuscarClientePorIdReserva(id);
        }

        [HttpPost("CrearCliente")]
        public bool CrearClientes(Cliente cliente)
        {
            return _businessSql.CrearCliente(cliente);
        }

        [HttpPut("EditarHabitacion")]
        public bool EditarCliente(String id, String nombre, String apellidos, String email)
        {
            return _businessSql.EditarCliente(id, nombre, apellidos, email);
        }
    }
}
