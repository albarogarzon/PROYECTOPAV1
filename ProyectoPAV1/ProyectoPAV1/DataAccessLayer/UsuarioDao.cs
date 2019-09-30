using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPAV1.Entities;
using System.Data;

namespace ProyectoPAV1.DataAccessLayer
{
    class UsuarioDao
    {
        public IList<Usuario> GetAll()
        {
            List<Usuario> listado = new List<Usuario>();


            //var strSql = "SELECT id_usuario, usuario, email, estado from Usuarios ";
            String strSql = string.Concat(" SELECT id_usuario, ",
                              "        usuario, ",
                              "        email, ",
                              "        estado, ",
                              "        password, ",
                              "        p.id_perfil, ",
                              "        p.nombre as perfil",
                              "   FROM Usuarios u",
                              "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil WHERE u.borrado=0 ");

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listado.Add(Mapping(row));
            }

            return listado;
        }

        public Usuario GetUser(string nombreUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        usuario, ",
                                          "        email, ",
                                          "        estado, ",
                                          "        password, ",
                                          "        p.id_perfil, ",
                                          "        p.nombre as perfil ",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                          "  WHERE u.borrado =0 ");

            strSql += " AND usuario=" + "'" + nombreUsuario + "'";

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return Mapping(resultado.Rows[0]);
            }

            return null;
        }


        public IList<Usuario> GetByFilters(String condiciones)
        {

            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT id_usuario, ",
                                              "        usuario, ",
                                              "        email, ",
                                              "        estado, ",
                                              "        password, ",
                                              "        p.id_perfil, ",
                                              "        p.nombre as perfil ",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                              "  WHERE u.borrado =0 ");


             
               strSql += condiciones;


            // if (parametros.ContainsKey("usuario"))
            //    strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(Mapping(row));

            return lst;
        }


        private Usuario Mapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                NombreUsuario = row["usuario"].ToString(),
                Email = row["email"].ToString(),
                Estado = row["estado"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null,
                Perfil = new Perfil()
                {
                    IdPerfil = Convert.ToInt32(row["id_perfil"].ToString()),
                    Nombre = row["perfil"].ToString(),
                }
            };

            return oUsuario;
        }

        internal bool Create(Usuario oUsuario)
        {
            //CON PARAMETROS
            //string str_sql = "     INSERT INTO Usuarios (usuario, password, email, id_perfil, estado, borrado)" +
            //                 "     VALUES (@usuario, @password, @email, @id_perfil, 'S', 0)";

            // var parametros = new Dictionary<string, object>();
            //parametros.Add("usuario", oUsuario.NombreUsuario);
            //parametros.Add("password", oUsuario.Password);
            //parametros.Add("email", oUsuario.Email);
            //parametros.Add("id_perfil", oUsuario.Perfil.IdPerfil);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            //con parametros
            //return (DBHelper.GetDBHelper().EjecutarSQLConParametros(str_sql, parametros) == 1);

            //SIN PARAMETROS

            string str_sql = "INSERT INTO Usuarios (usuario, password, email, estado, id_perfil, borrado)" +
                            " VALUES (" +
                            "'" + oUsuario.NombreUsuario + "'" + "," +
                            "'" + oUsuario.Password + "'" + "," +
                            "'" + oUsuario.Email + "'" + "," +
                            "'" + oUsuario.Estado + "'" + "," +
                            oUsuario.Perfil.IdPerfil + ",0)";


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Usuario oUsuario)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Usuarios " +
                             "SET usuario=" + "'" + oUsuario.NombreUsuario + "'" + "," +
                             " password=" + "'" + oUsuario.Password + "'" + "," +
                             " email=" + "'" + oUsuario.Email + "'" + "," +
                             " estado=" + "'" + oUsuario.Estado + "'" + "," +
                             " id_perfil=" + oUsuario.Perfil.IdPerfil +
                             " WHERE id_usuario=" + oUsuario.IdUsuario;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }


        internal bool Delete(Usuario oUsuario)
        {
            string str_sql = "UPDATE Usuarios " +
                             "SET borrado=" + "'" + true + "'" +
                             " WHERE id_usuario=" + oUsuario.IdUsuario;


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
    }
}
