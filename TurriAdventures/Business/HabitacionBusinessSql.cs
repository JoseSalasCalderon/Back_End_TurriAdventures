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
    public class HabitacionBusinessSql
    {
        HabitacionDataAccessSql _dataAccessSql;

        public HabitacionBusinessSql()
        {
            _dataAccessSql = new HabitacionDataAccessSql();
        }

        #region CRUDHabitacion
        public Task<List<Habitacion>> ListarHabitaciones()
        {
            return _dataAccessSql.ListarHabitaciones();
        }

        public bool CrearHabitacion(int estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int idTipoHabitacion)
        {
            return _dataAccessSql.CrearHabitacion(estadoHabitacion, numeroHabitacion, capacidadMaxima, idTipoHabitacion);
        }

        public Habitacion BuscarHabitacion(int idHabitacion)
        {
            return _dataAccessSql.BuscarHabitacion(idHabitacion);
        }

        public Habitacion BuscarHabitacionPorIdReserva(int idReserva)
        { 
            return _dataAccessSql.BuscarHabitacionPorIdReserva(idReserva);
        }

       
        public List<Habitacion> ConsultarDisponibilidadHabitaciones(string fechaLlegada, string fechaSalida, int tipo_habitacion_id)
        {
            return _dataAccessSql.ConsultarDisponibilidadHabitaciones(fechaLlegada, fechaSalida, tipo_habitacion_id);
        }

        public bool EditarHabitacion(int idHabitacion, int estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int idTipoHabitacion)
        {
            return _dataAccessSql.EditarHabitacion(idHabitacion, estadoHabitacion, numeroHabitacion, capacidadMaxima, idTipoHabitacion);
        }

        #endregion

    }
}
