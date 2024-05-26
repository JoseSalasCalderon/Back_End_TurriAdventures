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
    public class PublicidadBusinessSql
    {
        PublicidadDataAccessSql _dataAccessSql;

        public PublicidadBusinessSql()
        {
            _dataAccessSql = new PublicidadDataAccessSql();
        }

        #region CRUDPublicidad
        public Task<List<Publicidad>> ListarPublicidades()
        {
            return _dataAccessSql.ListarPublicidades();
        }//ListarListarPublicidades

        public Publicidad BuscarPublicidad(int idPublicidad)
        {
            return _dataAccessSql.BuscarPublicidad(idPublicidad);
        }//BuscarPublicidad

        public Publicidad BuscarPublicidadPorNombre(String nombrePublicidad)
        {
            return _dataAccessSql.BuscarPublicidadPorNombre(nombrePublicidad);
        }//BuscarPublicicadPorNombre

        public bool CrearPublicidad(Publicidad publicidad)
        {
            return _dataAccessSql.CrearPublicidad(publicidad);
        }//CrearPublicidad

        public bool modificarPublicidad(Publicidad publicidad)
        {
            return _dataAccessSql.ModificarPublicidad(publicidad);
        }//EditarContacto

        public bool EliminarPublicidad(int idPublicidad)
        {
            return _dataAccessSql.EliminarPublicidad(idPublicidad);
        }//EliminarPublicidad

        #endregion

    }
}
