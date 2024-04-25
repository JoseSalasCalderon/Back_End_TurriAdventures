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

        [HttpGet("BuscarAdministrador/{usuario}")]
        public async Task<Administrador> BuscarAdministrador(String usuario)
        {
            return _businessSql.BuscarAdministrador(usuario);
        }

        [HttpPost("CrearAdministrador")]
        public bool CrearAdministrador(Administrador administrador)
        {
            return _businessSql.CrearAdministrador(administrador);
        }

        [HttpPut("EditarAdministrador")]
        public bool EditarAdministrador(Administrador administrador)
        {
            return _businessSql.modificarAdministrador(administrador);
        }

        [HttpDelete("EliminarAdministrador/{id}")]
        public bool EliminarAdministrador(int id)
        {
            return _businessSql.EliminarAdministrador(id);
        }
    }
}