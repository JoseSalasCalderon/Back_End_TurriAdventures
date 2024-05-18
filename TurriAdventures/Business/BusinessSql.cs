using Data.Data;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurriAdventures.Entities;

namespace Business.Business
{
    public class BusinessSql
    {
        DataAccessSql _dataAccessSql;

        public BusinessSql()
        {
            _dataAccessSql = new DataAccessSql();
        }

        #region CRUDOferta
        public Task<List<Oferta>> ListarOfertas()
        {
            return _dataAccessSql.ListarOfertas();
        }

        public bool CrearOferta(string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            return _dataAccessSql.CrearOferta(descripcionOferta, fechaInicioOferta, fechaFinalOferta, precioOferta);
        }

        public Oferta BuscarOferta(int idOferta)
        {
            return _dataAccessSql.BuscarOferta(idOferta);
        }

        public bool EditarOferta(int idOferta, string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            return _dataAccessSql.EditarOferta(idOferta, descripcionOferta, fechaInicioOferta, fechaFinalOferta, precioOferta);
        }

        public bool EliminarOferta(int idOferta)
        {
            return _dataAccessSql.EliminarOferta(idOferta);
        }


        #endregion


        #region CRUDTemporada
        public Task<List<Temporada>> ListarTemporadas()
        {
            return _dataAccessSql.ListarTemporadas();
        }

        public bool CrearTemporada(String descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            return _dataAccessSql.CrearTemporada(descripcionTemporada,  fechaInicioTemporada,  fechaFinalTemporada,  precioTemporada);
        }

        public Temporada BuscarTemporada(int idHabitacion)
        {
            return _dataAccessSql.BuscarTemporada(idHabitacion);
        }

        public bool EditarTemporada(int idTemporada, String descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            return _dataAccessSql.EditarTemporada(idTemporada, descripcionTemporada, fechaInicioTemporada, fechaFinalTemporada, precioTemporada);
        }

        #endregion
    }
}
