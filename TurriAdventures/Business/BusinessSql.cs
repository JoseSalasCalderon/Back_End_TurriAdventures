using Data.Data;
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

        public Task<List<Oferta>> ListarOfertas()
        {
            return _dataAccessSql.ListarOfertas();
        }
    }
}
