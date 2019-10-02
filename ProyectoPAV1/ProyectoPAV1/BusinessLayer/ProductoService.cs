using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPAV1.Entities;
using ProyectoPAV1.DataAccessLayer;

namespace ProyectoPAV1.BusinessLayer
{
    class ProductoService
    {
        private ProductoDao oProductoDao;
        public ProductoService()
        {
            oProductoDao = new ProductoDao();
        }
        public IList<Producto> ObtenerTodos()
        {
            return oProductoDao.GetAll();
        }
        internal IList<Producto> ConsultarConFiltros(String condiciones)
        {
            return oProductoDao.GetByFilters(condiciones);
        }
        internal bool CrearProducto(Producto oProducto)
        {
            return oProductoDao.Create(oProducto);
        }

        internal bool ActualizarProducto(Producto oProductoSelected)
        {
            return oProductoDao.Update(oProductoSelected);
        }


        internal bool ModificarEstadoProducto(Producto oProductoSelected)
        {
            return oProductoDao.Delete(oProductoSelected);
            //throw new NotImplementedException();
        }

        internal object ObtenerProducto(string producto)
        {
            return oProductoDao.GetProductosSinParametros(producto);
            
        }
    }
}
