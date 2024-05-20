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
    public class HomeBusinessSql
    {
        HomeDataAccessSql _dataAccessSql;

        public HomeBusinessSql()
        {
            _dataAccessSql = new HomeDataAccessSql();
        }

        #region CRUDHome
        public Task<List<Home>> ListarHomes()
        {
            return _dataAccessSql.ListarHomes();
        }//ListarListarHomes

        public Home BuscarHome(int idHome)
        {
            return _dataAccessSql.BuscarHome(idHome);
        }//BuscarHome

        public bool CrearHome(Home home)
        {
            return _dataAccessSql.CrearHome(home);
        }//CrearHome

        public bool modificarHome(Home home)
        {
            return _dataAccessSql.ModificarHome(home);
        }//EditarHome

        public bool EliminarHome(int idHome)
        {
            return _dataAccessSql.EliminarHome(idHome);
        }//EliminarHome

        #endregion

    }
}
