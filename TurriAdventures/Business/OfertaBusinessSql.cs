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
    public class OfertaBusinessSql
    {
        OfertaDataAccessSql _dataAccessSql;

        public OfertaBusinessSql()
        {
            _dataAccessSql = new OfertaDataAccessSql();
        }

        #region CRUDOferta
        public Task<List<Ofertum>> ListarOfertas()
        {
            return _dataAccessSql.ListarOfertas();
        }

        public bool CrearOferta(string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            return _dataAccessSql.CrearOferta(descripcionOferta, fechaInicioOferta, fechaFinalOferta, precioOferta);
        }

        public Ofertum BuscarOferta(int idOferta)
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
    }
}
