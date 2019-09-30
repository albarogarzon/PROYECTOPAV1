using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPAV1.Entities;
using ProyectoPAV1.DataAccessLayer;

namespace ProyectoPAV1.BusinessLayer
{
    class UsuarioService
    {
        private UsuarioDao oUsuarioDao;
        public UsuarioService()
        {
            oUsuarioDao = new UsuarioDao();
        }
        public IList<Usuario> ObtenerTodos()
        {
            return oUsuarioDao.GetAll();
        }

        public Usuario ValidarUsuario(string usuario, string password)
        {
            var usr = oUsuarioDao.GetUser(usuario); //sin paramentros? 

            if (usr.Password != null && usr.Password.Equals(password))
            {
                return usr;
            }

            return null;
        }
        internal bool CrearUsuario(Usuario oUsuario)
        {
            return oUsuarioDao.Create(oUsuario);
        }

        internal bool ActualizarUsuario(Usuario oUsuarioSelected)
        {
            return oUsuarioDao.Update(oUsuarioSelected);
        }

        internal bool ModificarEstadoUsuario(Usuario oUsuarioSelected)
        {
            return oUsuarioDao.Delete(oUsuarioSelected);
            //throw new NotImplementedException();
        }

        internal object ObtenerUsuario(string usuario)
        {
            //SIN PARAMETROS
            return oUsuarioDao.GetUser(usuario);

            //CON PARAMETROS
            // return oUsuarioDao.GetUserConParametros(usuario);
        }


        internal IList<Usuario> ConsultarConFiltros(String condiciones)
        {
            return oUsuarioDao.GetByFilters(condiciones);
        }


    }
}
