using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IAteneav2.Models
{
    public class MWebSites
    {
        Logic.Conexion conexion = new Logic.Conexion();

        /// <summary>
        /// Toma todos los urls y los pone en una lista
        /// </summary>
        /// <returns>Lista de websites</returns>
        public LinkedList<Clases.WebSite> getWebSites()
        {
            bool isConected = conexion.conectarServer();
            LinkedList<Clases.WebSite> lista = new LinkedList<Clases.WebSite>();
            try
            {
                if (isConected)
                {
                    // select * from Palabra where ID = 0;
                    string sql = @"select * from WebSites;";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Clases.WebSite webSite = new Clases.WebSite(reader.GetInt32(0), reader.GetString(1));
                                lista.AddLast(webSite);
                                //result.setNombre(reader.GetString(1));
                                //result.setIdioma(cidioma.Select(reader.GetByte(2)));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return lista;
            }
            finally {
                conexion.desconectar();
            }
            return lista;
        }

        /// <summary>
        /// Agrega websites a la tabla de websites
        /// </summary>
        /// <param name="url">el url del website</param>
        /// <returns>True si fue exitoso y false si hubo error</returns>
        public bool agregarWebSite(string url)
        {
            bool isConected = conexion.conectarServer();
            bool respuesta = false;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conexion.Conexionc;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO WebSites(Url) VALUES(@Url)";
                command.Parameters.AddWithValue("@Url", url);

                try
                {
                    if (isConected)
                    {
                        command.ExecuteNonQuery();
                        respuesta = true;
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
                finally
                {
                    conexion.desconectar();
                }
            }
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        internal bool quitarWebSite(string url)
        {
            bool isConected = conexion.conectarServer();
            bool respuesta = false;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conexion.Conexionc;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM WebSites WHERE Url = @url";
                command.Parameters.AddWithValue("@url", url);

                try
                {
                    if (isConected)
                    {
                        command.ExecuteNonQuery();
                        respuesta = true;
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
                finally
                {
                    conexion.desconectar();
                }
            }
            return respuesta;
        }
    }
}
            
