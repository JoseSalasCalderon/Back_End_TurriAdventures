using Data.Data;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class FacilidadBusinessSql
    {
        FacilidadDataAccessSql _dataAccessSql;

        public FacilidadBusinessSql()
        {
            _dataAccessSql = new FacilidadDataAccessSql();
        }
        #region CRUDFacilidad
        public Task<List<Facilidad>> ListarFacilidades()
        {
            return _dataAccessSql.ListarFacilidades();
        }//ListarTipoHabitaciones

        public bool CrearFacilidad(Facilidad facilidad)
        {
            return _dataAccessSql.CrearFacilidad(facilidad);
        }//CrearFacilidad

        public Facilidad BuscarFacilidad(int idFacilidad)
        {
            return _dataAccessSql.BuscarFacilidad(idFacilidad);
        }//BuscarFacilidad

        public bool modificarFacilidad(Facilidad facilidad)
        {
            return _dataAccessSql.modificarFacilidad(facilidad);
        }//modificarFacilidad

        public bool EliminarFacilidad(int idFacilidad)
        {
            return _dataAccessSql.EliminarFacilidad(idFacilidad);
        }//EliminarFacilidad

        #endregion

    }
}
