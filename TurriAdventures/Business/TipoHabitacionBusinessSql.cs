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
    public class TipoHabitacionBusinessSql
    {
        TipoHabitacionDataAccessSql _dataAccessSql;

        public TipoHabitacionBusinessSql()
        {
            _dataAccessSql = new TipoHabitacionDataAccessSql();
        }

        #region CRUDTipoHabitacion
        public Task<List<TipoHabitacion>> ListarTipoHabitaciones()
        {
            return _dataAccessSql.ListarTipoHabitaciones();
        }

        public bool CrearTipoHabitacion(String nombreTipoHabitacion, decimal precio, String descripcionTipoHabitacion, String imagenTipoHabitacion, int idOferta, int idTemporada)
        {
            return _dataAccessSql.CrearTipoHabitacion(nombreTipoHabitacion, precio, descripcionTipoHabitacion, imagenTipoHabitacion, idOferta,  idTemporada);
        }

        public TipoHabitacion BuscarTipoHabitacion(int idHabitacion)
        {
            return _dataAccessSql.BuscarTipoHabitacion(idHabitacion);
        }

        public TipoHabitacion BuscarTipoHabitacionPorHabitacion(int idHabitacion)
        {
            return _dataAccessSql.BuscarTipoHabitacionPorHabitacion(idHabitacion);
        }

            public bool EditarTipoHabitacion(TipoHabitacion tipoHabitacion)
        {
            return _dataAccessSql.EditarTipoHabitacion(tipoHabitacion);
        }

        #endregion

        }
}
