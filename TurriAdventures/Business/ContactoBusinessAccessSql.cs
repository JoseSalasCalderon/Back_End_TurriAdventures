using Data.Data;
using Entities.Entities;
using System.Diagnostics.Contracts;

namespace Business
{
    public class ContactoBusinessAccessSql
    {
        ContactoDataAccessSql _dataAccessSql;

        public ContactoBusinessAccessSql()
        {
            _dataAccessSql = new ContactoDataAccessSql();
        }

        #region CRUDContacto
        public Task<List<Contacto>> ListarContactos()
        {
            return _dataAccessSql.ListarContactos();
        }//ListarListarContactos

        public bool CrearContacto(String telefono1, String telefono2, String apartadoPostal, String email)
        {
            return _dataAccessSql.CrearContacto(telefono1, telefono2, apartadoPostal, email);
        }//CrearContacto

        public bool modificarContacto(Contacto contacto)
        {
            return _dataAccessSql.modificarContacto(contacto);
        }//EditarContacto

        public bool EliminarContacto(int idContacto)
        {
            return _dataAccessSql.EliminarContacto(idContacto);
        }
        #endregion

    }
}
