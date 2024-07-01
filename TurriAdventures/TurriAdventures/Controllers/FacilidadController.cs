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
        private readonly FacilidadBusinessSql _businessSql = new FacilidadBusinessSql();

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
        public bool CrearFacilidad(Facilidad facilidad)
        {
            return _businessSql.CrearFacilidad(facilidad);
        }

        [HttpPut("EditarFacilidad")]
        public bool EditarFacilidad(Facilidad facilidad)
        {
            return _businessSql.modificarFacilidad(facilidad);
        }

        [HttpDelete("EliminarFacilidad/{id}")]
        public bool EliminarFacilidad(int id)
        {
            return _businessSql.EliminarFacilidad(id);
        }
    }
}
