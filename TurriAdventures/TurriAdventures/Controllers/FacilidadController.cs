using Business.Business;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TurriAdventures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilidadController : ControllerBase
    {
        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly BusinessSql _businessSql = new BusinessSql();

        [HttpGet("ListarFacilidades")]
        public Task<List<Facilidad>> ListarFacilidades()
        {
            return _businessSql.ListarFacilidades();
        }

        [HttpGet("BuscarFacilidad/{id}")]
        public async Task<Facilidad> BuscarFacilidad(int id)
        {
            return _businessSql.BuscarFacilidad(id);
        }

        [HttpPost("CrearFacilidad")]
        public bool CrearFacilidad(String descripcionFacilidad, String imagenFacilidad)
        {
            return _businessSql.CrearFacilidad(descripcionFacilidad, imagenFacilidad);
        }

        [HttpPut("EditarFacilidad")]
        public bool EditarFacilidad(int idFacilidad, String descripcionFacilidad, String imagenFacilidad)
        {
            return _businessSql.modificarFacilidad(idFacilidad, descripcionFacilidad, imagenFacilidad);
        }

        //[HttpDelete("EliminarFacilidad")]
        //public bool EliminarFacilidad(int id)
        //{
        //    return _businessSql.EliminarFacilidad(id);
        //}
    }
}
