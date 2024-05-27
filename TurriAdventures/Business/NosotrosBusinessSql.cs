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

       }
}
