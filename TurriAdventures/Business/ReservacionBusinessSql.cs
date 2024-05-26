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
    public class ReservacionBusinessSql
    {
        ReservacionDataAccessSql _dataAccessSql;

        public ReservacionBusinessSql()
        {
            _dataAccessSql = new ReservacionDataAccessSql();
        }

        #region CRUDReservacion
        public Task<List<Reservacion>> ListarReservas()
        {
            return _dataAccessSql.ListarReservas();
        }

        public int CrearReserva(Reservacion reservacion)
        {
            return _dataAccessSql.CrearReserva(reservacion);
        }

        public Reservacion BuscarReservaPorIdCliente(String idCliente)
        {
            return _dataAccessSql.BuscarReservaPorIdCliente(idCliente);
        }

        public bool modificarReserva(Reservacion reservacion)
        {
            return _dataAccessSql.modificarReserva(reservacion);
        }

        #endregion
    }
}
