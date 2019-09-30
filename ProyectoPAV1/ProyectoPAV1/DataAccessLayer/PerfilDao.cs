using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPAV1.Entities;
using System.Data;


namespace ProyectoPAV1.DataAccessLayer
{
    public class PerfilDao
    {
        public IList<Perfil> GetAll()
        {
            List<Perfil> listadoBugs = new List<Perfil>();

            var strSql = "SELECT * From Perfiles WHERE id_perfil <> 1 AND borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(ObjectMapping(row));
            }

            return listadoBugs;
        }

        private Perfil ObjectMapping(DataRow row)
        {
            Perfil oPerfil = new Perfil
            {
                IdPerfil = Convert.ToInt32(row["id_Perfil"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oPerfil;
        }
    }
}
