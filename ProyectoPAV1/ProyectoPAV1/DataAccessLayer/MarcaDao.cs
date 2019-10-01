using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoPAV1.Entities;

namespace ProyectoPAV1.DataAccessLayer
{
    class MarcaDao
    {
        public IList<Marca> GetAll()
        {
            List<Marca> listado = new List<Marca>();

            var strSql = "SELECT idMarca, nombre from Marcas  where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listado.Add(Mapping(row));
            }

            return listado;
        }

        private Marca Mapping(DataRow row)
        {
            Marca oMarca = new Marca
            {
                IdMarca = Convert.ToInt32(row["idMarca"].ToString()),
                NombreMarca = row["nombre"].ToString()
            };

            return oMarca;
        }


        public IList<Marca> GetByFilters(String condiciones)
        {

            List<Marca> lst = new List<Marca>();
            String strSql = string.Concat(" SELECT idMarca, ",
                                              "        nombre ",
                                              "   FROM Marcas",
                                              "  WHERE borrado =0 ");



            strSql += condiciones;


            // if (parametros.ContainsKey("usuario"))
            //    strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(Mapping(row));

            return lst;
        }


        public Marca GetMarca(string nombreMarca)
        {
            
            String strSql = string.Concat(" SELECT idMarca, ",
                                          "        nombre ",   
                                          "  FROM Marcas WHERE borrado =0 ");

            strSql += " AND nombre=" + "'" + nombreMarca + "'";

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return Mapping(resultado.Rows[0]);
            }

            return null;
        }

        internal bool Create(Marca oMarca)
        {
            //modificar

            string str_sql = "INSERT INTO Marcas (nombre, borrado)" +
                            " VALUES (" +
                            "'" + oMarca.NombreMarca + "'" +
                            ",0)";


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Marca oMarca)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Marcas " +
                             "SET nombre=" + "'" + oMarca.NombreMarca + "'" +   
                             " WHERE idMarca=" + oMarca.IdMarca;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Delete(Marca oMarca)
        {
            string str_sql = "UPDATE Marcas " +
                             "SET borrado=" + "'" + true + "'" +
                             " WHERE idMarca=" + oMarca.IdMarca;


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

    }
}
