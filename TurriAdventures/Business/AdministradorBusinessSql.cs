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
    public class AdministradorBusinessSql
    {
        AdministradorDataAccessSql _dataAccessSql;

        public AdministradorBusinessSql()
        {
            _dataAccessSql = new AdministradorDataAccessSql();
        }

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
