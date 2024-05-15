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
    public class PublicidadsController : ControllerBase
    {

        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        [HttpGet("ListarPublicidades")]
        public Task<List<Publicidad>> ListarPublicidades()
        {
            return _businessSql.ListarPublicidades();
        }

        [HttpGet("BuscarPublicidad/{idPublicidad}")]
        public async Task<Publicidad> BuscarPublicidad(int idPublicidad)
        {
            return _businessSql.BuscarPublicidad(idPublicidad);
        }

        [HttpPost("CrearPublicidad")]
        public bool CrearPublicidad(Publicidad publicidad)
        {
            return _businessSql.CrearPublicidad(publicidad);
        }

        [HttpPut("EditarPublicidad")]
        public bool EditarAdministrador(Publicidad publicidad)
        {
            return _businessSql.modificarPublicidad(publicidad);
        }

        [HttpDelete("EliminarPublicidad/{idPublicidad}")]
        public bool EliminarPublicidad(int idPublicidad)
        {
            return _businessSql.EliminarPublicidad(idPublicidad);
        }
    }
}
