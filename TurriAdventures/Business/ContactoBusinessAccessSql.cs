using Data.Data;
using Entities.Entities;


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

        public bool modificarContacto(int idContacto, String telefono1, String telefono2, String apartadoPostal, String email)
        {
            return _dataAccessSql.modificarContacto(idContacto, telefono1, telefono2, apartadoPostal, email);
        }//EditarContacto

        public bool EliminarContacto(int idContacto)
        {
            return _dataAccessSql.EliminarContacto(idContacto);
        }
        #endregion

    }
}
