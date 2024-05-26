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

        public bool CrearFacilidad(String descripcionFacilidad, String imagenFacilidad)
        {
            return _dataAccessSql.CrearFacilidad(descripcionFacilidad, imagenFacilidad);
        }//CrearFacilidad

        public Facilidad BuscarFacilidad(int idFacilidad)
        {
            return _dataAccessSql.BuscarFacilidad(idFacilidad);
        }//Facilidad

        public bool modificarFacilidad(int idFacilidad, String descripcionFacilidad, String imagenFacilidad)
        {
            return _dataAccessSql.modificarFacilidad(idFacilidad, descripcionFacilidad, imagenFacilidad);
        }//EditarHabitacion
        #endregion
    }
}
