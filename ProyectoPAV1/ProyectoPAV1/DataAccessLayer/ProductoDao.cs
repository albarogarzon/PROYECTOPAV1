using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoPAV1.Entities;

namespace ProyectoPAV1.DataAccessLayer
{
    class ProductoDao
    {
        public IList<Producto> GetAll()
        {
            List<Producto> listado = new List<Producto>();

            var strSql = "SELECT id_producto, nombre from Productos  where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listado.Add(Mapping(row));
            }

            return listado;
        }

        private Producto Mapping(DataRow row)
        {
            Producto oProducto = new Producto
            {
                IdProducto = Convert.ToInt32(row["id_producto"].ToString()),
                NombreProducto = row["nombre"].ToString(),
                DescripciónProducto = row["descripcion"].ToString(),
                StockProducto = row["stock"].ToString(),
                PrecioProducto = row.Table.Columns.Contains("precioVenta") ? row["precioVenta"].ToString() : null,
            };

            return oProducto;
        }

        private Producto ObjectMapping(DataRow row)
        {
            Producto oProducto = new Producto
            {
                IdProducto = Convert.ToInt32(row["id_producto"].ToString()),
                NombreProducto = row["nombre"].ToString(),
                DescripciónProducto = row["descripcion"].ToString(),
                StockProducto = row["stock"].ToString(),
                PrecioProducto = row.Table.Columns.Contains("precioVenta") ? row["precioVenta"].ToString() : null,
                MarcaProducto = new Marca()
                {
                    IdMarca = Convert.ToInt32(row["idMarca"].ToString()),
                    NombreMarca = row["NombreMarca"].ToString(),
                }
            };

            return oProducto;
        }
        public IList<Producto> GetByFilters(String condiciones)
        {
            string strSql = " ";
            List<Producto> lst = new List<Producto>();
            strSql = string.Concat(" SELECT p.id_producto, ",
                                              "        p.nombre, ",
                                          "        p.descripcion, ",
                                          "        p.stock, ",
                                          "        p.precioVenta, ",
                                          "        m.idMarca, ",
                                          "        m.nombre as NombreMarca ",
                                              "   FROM Productos as p",
                                          "  INNER JOIN Marcas m ON p.marcaProducto= m.idMarca ",
                                              "  WHERE p.borrado =0  ");



            strSql += condiciones;


            // if (parametros.ContainsKey("usuario"))
            //    strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        public Producto GetProductosSinParametros(string nombreProducto)
        {
            String strSql = string.Concat(" SELECT id_producto, ",
                                          "        p.nombre, ",
                                          "        descripcion, ",
                                          "        stock, ",
                                          "        precioVenta, ",
                                          "        m.idMarca, ",
                                          "        m.nombre as NombreMarca ",
                                          "   FROM Productos p",
                                          "  INNER JOIN Marcas m ON p.marcaProducto= m.idMarca ",
                                          "  WHERE p.borrado =0 ");

            strSql += " AND p.nombre=" + "'" + nombreProducto + "'";


            
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        internal bool Create(Producto oProducto)
        {
           

            string str_sql = "INSERT INTO Productos (nombre, descripcion, stock, precioVenta, marcaProducto, borrado)" +
                            " VALUES (" +
                            "'" + oProducto.NombreProducto + "'" + "," +
                            "'" + oProducto.DescripciónProducto + "'" + "," +
                            "'" + oProducto.StockProducto + "'" + "," +
                            "'" + oProducto.PrecioProducto + "'" + "," +
                            oProducto.MarcaProducto.IdMarca + ",0)";


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Producto oProducto)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Productos " +
                             "SET nombre=" + "'" + oProducto.NombreProducto + "'" + "," +
                             " descripcion=" + "'" + oProducto.DescripciónProducto + "'" + "," +
                             " stock=" + "'" + oProducto.StockProducto + "'" + "," +
                             " precioVenta=" + "'" + oProducto.PrecioProducto + "'" + "," +
                             " marcaProducto=" + oProducto.MarcaProducto.IdMarca +
                             " WHERE id_producto=" + oProducto.IdProducto;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
        internal bool Delete(Producto oProducto)
        {
            string str_sql = "UPDATE Productos " +
                                "SET borrado=" + "'" + true + "'" +
                                " WHERE id_producto=" + oProducto.IdProducto;


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);


        }

    }
}
