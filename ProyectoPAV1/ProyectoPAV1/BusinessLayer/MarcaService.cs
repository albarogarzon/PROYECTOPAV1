using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPAV1.Entities;
using ProyectoPAV1.DataAccessLayer;

namespace ProyectoPAV1.BusinessLayer
{
    class MarcaService
    {
        private MarcaDao oMarcaDao;
        public MarcaService()
        {
            oMarcaDao = new MarcaDao();
        }
        public IList<Marca> ObtenerTodos()
        {
            return oMarcaDao.GetAll();
        }

        internal IList<Marca> ConsultarConFiltros(String condiciones)
        {
            return oMarcaDao.GetByFilters(condiciones);
        }

        internal object ObtenerMarca(string marca)
        {
            //SIN PARAMETROS
            return oMarcaDao.GetMarca(marca);

            //CON PARAMETROS
            // return oUsuarioDao.GetUserConParametros(usuario);
        }

        internal bool CrearMarca(Marca oMarca)
        {
            return oMarcaDao.Create(oMarca);
        }
        internal bool ActualizarMarca(Marca oMarcaSelected)
        {
            return oMarcaDao.Update(oMarcaSelected);
        }
        internal bool ModificarEstadoMarca(Marca oMarcaSelected)
        {
            return oMarcaDao.Delete(oMarcaSelected);
            //throw new NotImplementedException();
        }
    }
}
