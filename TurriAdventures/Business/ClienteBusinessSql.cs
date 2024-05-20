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
    public class ClienteBusinessSql
    {
        ClienteDataAccessSql _dataAccessSql;

        public ClienteBusinessSql()
        {
            _dataAccessSql = new ClienteDataAccessSql();
        }

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

        public Cliente BuscarClientePorIdReserva(int idReserva)
        {
            return _dataAccessSql.BuscarClientePorIdReserva(idReserva);
        }

        public bool EditarCliente(String id,String nombre, String apellidos, String email)
        {
            return _dataAccessSql.EditarCliente( id,nombre, apellidos, email);
        }

        #endregion

    }
}
