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


    }
}
