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
    public class TemporadaBusinessSql
    {
        TemporadaDataAccessSql _dataAccessSql;

        public TemporadaBusinessSql()
        {
            _dataAccessSql = new TemporadaDataAccessSql();
        }

     
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


        public  Task<Temporada> eliminarTemporada(int id)
        {
            return _dataAccessSql.eliminarTemporada(id);
        }

        #endregion

    }
}
