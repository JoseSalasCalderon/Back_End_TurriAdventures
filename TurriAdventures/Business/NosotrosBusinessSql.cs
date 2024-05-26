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
    public class NosotrosBusinessSql
    {
        NosotrosDataAccessSql _dataAccessSql;

        public NosotrosBusinessSql()
        {
            _dataAccessSql = new NosotrosDataAccessSql();
        }

      

        #region CRUDNosotros
        public Task<List<Nosotro>> ListarNosotros()
        {
            return _dataAccessSql.ListarNosotros();
        }//ListarListarNosotros

        public bool CrearNosotros(Nosotro nosotros)
        {
            return _dataAccessSql.CrearNosotros(nosotros);
        }//CrearNosotros

        public Nosotro BuscarNosotros(int idNosotros)
        {
            return _dataAccessSql.BuscarNosotros(idNosotros);
        }//BuscarNosotros

        public bool modificarNosotros(Nosotro nosotros)
        {
            return _dataAccessSql.modificarNosotros(nosotros);
        }//EditarNosotros
        #endregion

       }
}
