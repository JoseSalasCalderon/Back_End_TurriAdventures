using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Business.Business;

namespace TurriAdventures.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {

        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        [HttpGet("ListarAdministradores")]
        public Task<List<Administrador>> ListarAdministradores()
        {
            return _businessSql.ListarAdministradores();
        }

        [HttpGet("BuscarAdministrador/{id}")]
        public async Task<Administrador> BuscarAdministrador(int id)
        {
            return _businessSql.BuscarAdministrador(id);
        }

        [HttpPost("CrearAdministrador")]
        public bool CrearAdministrador(String usuario, String contrasena)
        {
            return _businessSql.CrearAdministrador(usuario, contrasena);
        }

        [HttpPut("EditarAdministrador")]
        public bool EditarAdministrador(int idAdministrador, String usuario, String contrasena)
        {
            return _businessSql.modificarAdministrador(idAdministrador, usuario, contrasena);
        }

        [HttpDelete("EliminarAdministrador")]
        public bool EliminarAdministrador(int id)
        {
            return _businessSql.EliminarAdministrador(id);
        }
    }
}