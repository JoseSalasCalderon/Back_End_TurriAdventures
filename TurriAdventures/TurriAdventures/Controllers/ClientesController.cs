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
        private readonly BusinessSql _businessSql = new BusinessSql();

        // GET: Lista todas las habitaciones
        [HttpGet("ListarClientes")]
        public Task<List<Cliente>> ListarClientes()
        {
            return _businessSql.ListarClientes();
        }

        // GET: Detalles de una habitacion
        [HttpGet("BuscarCliente/{id}")]
        public async Task<Cliente> BuscarCliente(String id)
        {
            return _businessSql.BuscarCliente(id);
        }

        // POST: Crea una nueva oferta
        [HttpPost("CrearClientes")]
        public bool CrearClientes(String cedula, String nombre, String apellidos, String email)
        {
            return _businessSql.CrearClientes(cedula, nombre, apellidos, email);
        }

        // PUT: Actualiza una oferta existente
        [HttpPut("EditarHabitacion")]
        public bool EditarCliente(String id, String nombre, String apellidos, String email)
        {
            return _businessSql.EditarCliente(id, nombre, apellidos, email);
        }
    }
}
