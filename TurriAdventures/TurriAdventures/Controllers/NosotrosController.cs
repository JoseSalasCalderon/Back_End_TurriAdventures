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
    public class NosotrosController : ControllerBase
    {

        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        [HttpGet("ListarNosotros")]
        public Task<List<Nosotros>> ListarNosotros()
        {
            return _businessSql.ListarNosotros();
        }

        [HttpGet("BuscarNosotros/{id}")]
        public async Task<Nosotros> BuscarNosotros(int id)
        {
            return _businessSql.BuscarNosotros(id);
        }

        [HttpPost("CrearNosotros")]
        public bool CrearNosotros(String descripcionNosotros, String imagenNosotros)
        {
            return _businessSql.CrearNosotros(descripcionNosotros, imagenNosotros);
        }

        [HttpPut("EditarNosotros")]
        public bool EditarNosotros(int idNosotros, String descripcionNosotros, String imagenNosotros)
        {
            return _businessSql.modificarNosotros(idNosotros, descripcionNosotros, imagenNosotros);
        }

        //[HttpDelete("EliminarNosotros")]
        //public bool EliminarNosotros(int id)
        //{
        //    return _businessSql.EliminarNosotros(id);
        //}
    }
}