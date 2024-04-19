using Data.Data;
using Entities.Entities;
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

        public bool EditarHabitacion(int idHabitacion, int estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int idTipoHabitacion)
        {
            return _dataAccessSql.EditarHabitacion(idHabitacion, estadoHabitacion, numeroHabitacion, capacidadMaxima, idTipoHabitacion);
        }

        #endregion

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

        public bool EditarTipoHabitacion(int idHabitacion, String nombreTipoHabitacion, decimal precio, String descripcionTipoHabitacion, String imagenTipoHabitacion, int idOferta, int idTemporada)
        {
            return _dataAccessSql.EditarTipoHabitacion(idHabitacion, nombreTipoHabitacion, precio, descripcionTipoHabitacion, imagenTipoHabitacion, idOferta, idTemporada);
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

        #region CRUDCliente
        public Task<List<Cliente>> ListarClientes()
        {
            return _dataAccessSql.ListarClientes();
        }

        public bool CrearClientes( String cedula, String nombre, String apellidos, String email)
        {
            return _dataAccessSql.CrearClientes(cedula, nombre, apellidos, email);
        }

        public Cliente BuscarCliente(String idCliente)
        {
            return _dataAccessSql.BuscarCliente(idCliente);
        }

        public bool EditarCliente(String id,String nombre, String apellidos, String email)
        {
            return _dataAccessSql.EditarCliente( id,nombre, apellidos, email);
        }

        #endregion

        #region CRUDReservacion
        public Task<List<Reservacion>> ListarReservas()
        {
            return _dataAccessSql.ListarReservas();
        }

        public bool CrearReserva(DateTime fechaLlegada, DateTime fechaSalida, String estadoReservacion, int idHabitacion, String idCliente)
        {
            return _dataAccessSql.CrearReserva(fechaLlegada, fechaSalida, estadoReservacion, idHabitacion, idCliente);
        }

        public Reservacion BuscarReservaPorIdCliente(String idCliente)
        {
            return _dataAccessSql.BuscarReservaPorIdCliente(idCliente);
        }

        public bool modificarReserva(DateTime fechaLlegada, DateTime fechaSalida, String estadoReservacion, int idHabitacion, String idCliente)
        {
            return _dataAccessSql.modificarReserva(fechaLlegada, fechaSalida, estadoReservacion,idHabitacion,idCliente);
        }

        #endregion




    }
}
