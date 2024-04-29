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

        public Habitacion ConsultarDisponibilidadHabitaciones(String fechaLlegada, String fechaSalida, int tipo_habitacion_id)
        {
            return _dataAccessSql.ConsultarDisponibilidadHabitaciones(fechaLlegada, fechaSalida, tipo_habitacion_id);
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

        public bool CrearCliente(Cliente cliente)
        {
            return _dataAccessSql.CrearCliente(cliente);
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

        #region CRUDReservacion
        public Task<List<Reservacion>> ListarReservas()
        {
            return _dataAccessSql.ListarReservas();
        }

        public bool CrearReserva(Reservacion reservacion)
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

        #region CRUDNosotros
        public Task<List<Nosotros>> ListarNosotros()
        {
            return _dataAccessSql.ListarNosotros();
        }//ListarListarNosotros

        public bool CrearNosotros(Nosotros nosotros)
        {
            return _dataAccessSql.CrearNosotros(nosotros);
        }//CrearNosotros

        public Nosotros BuscarNosotros(int idNosotros)
        {
            return _dataAccessSql.BuscarNosotros(idNosotros);
        }//BuscarNosotros

        public bool modificarNosotros(Nosotros nosotros)
        {
            return _dataAccessSql.modificarNosotros(nosotros);
        }//EditarNosotros
        #endregion

        #region CRUDContacto
        public Task<List<Contacto>> ListarContactos()
        {
            return _dataAccessSql.ListarContactos();
        }//ListarListarContactos

        public bool CrearContacto(String telefono1, String telefono2, String apartadoPostal, String email)
        {
            return _dataAccessSql.CrearContacto(telefono1, telefono2, apartadoPostal, email);
        }//CrearContacto

        public bool modificarContacto(int idContacto, String telefono1, String telefono2, String apartadoPostal, String email)
        {
            return _dataAccessSql.modificarContacto(idContacto, telefono1, telefono2, apartadoPostal, email);
        }//EditarContacto

        public bool EliminarContacto(int idContacto)
        {
            return _dataAccessSql.EliminarContacto(idContacto);
        }
        #endregion

        #region CRUDAdministrador
        public Task<List<Administrador>> ListarAdministradores()
        {
            return _dataAccessSql.ListarAdministradores();
        }//ListarListarAdministradores

        public Administrador BuscarAdministrador(String usuario)
        {
            return _dataAccessSql.BuscarAdministrador(usuario);
        }//BuscarAdministrador

        public bool CrearAdministrador(Administrador administrador)
        {
            return _dataAccessSql.CrearAdministrador(administrador);
        }//CrearAdministrador

        public bool modificarAdministrador(Administrador administrador)
        {
            return _dataAccessSql.ModificarAdministrador(administrador);
        }//EditarContacto

        public bool EliminarAdministrador(int idAdministrador)
        {
            return _dataAccessSql.EliminarAdministrador(idAdministrador);
        }//EliminarAdministrador


        #endregion

    }
}
