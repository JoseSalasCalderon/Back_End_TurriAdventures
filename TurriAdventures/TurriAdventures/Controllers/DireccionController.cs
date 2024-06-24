using Business;
using Business.Business;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TurriAdventures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private readonly DireccionBusinessSql _businessSql = new DireccionBusinessSql();

        [HttpGet("ListarDirecciones")]
        public async Task<List<Direccion>> ListarDirecciones()
        {
            return await _businessSql.ListarDirecciones();
        }

        [HttpPost("CrearDireccion")]
        public bool CrearDireccion(Direccion direccion)
        {
            return _businessSql.CrearDireccion(direccion);
        }

        [HttpGet("BuscarDireccion/{id}")]
        public Direccion BuscarDireccion(int id)
        {
            return _businessSql.BuscarDireccion(id);
        }

        [HttpPut("EditarDireccion")]
        public Task<bool> EditarDireccion(Direccion direccion)
        {
            return _businessSql.EditarDireccion(direccion.IdDireccion, direccion.InformacionDireccion);
        }
    }
}
