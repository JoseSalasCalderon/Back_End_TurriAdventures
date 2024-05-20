using Data.Data;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DireccionBusinessSql
    {
        DireccionDataAccessSql _dataAccessSql;

        public DireccionBusinessSql()
        {
            _dataAccessSql = new DireccionDataAccessSql();
        }

        public async Task<List<Direccion>> ListarDirecciones()
        {
            return await _dataAccessSql.ListarDirecciones();
        }

        public bool CrearDireccion(Direccion direccion)
        {
            return _dataAccessSql.CrearDireccion(direccion);
        }

        public Direccion BuscarDireccion(int idDireccion)
        {
            return _dataAccessSql.BuscarDireccion(idDireccion);
        }

        public bool EditarDireccion(int idDireccion, string informacionDireccion)
        {
            return _dataAccessSql.EditarDireccion(idDireccion, informacionDireccion);
        }
    }
}
