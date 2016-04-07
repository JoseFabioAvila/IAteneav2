using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IAteneav2.Clases;
using System.Data.SqlClient;
using System.Data;

namespace IAteneav2.Models
{
    /// <summary>
    /// Modelo de idiomas
    /// </summary>
    public class MIdiomas
    {
        //instancia de conexion
        Logic.Conexion conexion = new Logic.Conexion();

        /// <summary>
        /// toma la lista de idiomas
        /// </summary>
        /// <returns>lista de idiomas</returns>
        public LinkedList<Clases.Idioma> getIdiomas()
        {
            bool isConected = conexion.conectarServer();
            LinkedList<Clases.Idioma> lista = new LinkedList<Clases.Idioma>();
            try
            {
                if (isConected)
                {
                    // select * from Palabra where ID = 0;
                    string sql = @"select * from Idioma;";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Clases.Idioma idioma = new Clases.Idioma(reader.GetInt32(0), reader.GetString(1));
                                lista.AddLast(idioma);
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
            finally
            {
                conexion.desconectar();
            }
            return lista;
        }
        
        /// <summary>
        /// agrega idomas 
        /// </summary>
        /// <param name="idioma">idioma</param>
        /// <returns></returns>
        public bool agregarIdioma(string idioma)
        {
            bool isConected = conexion.conectarServer();
            bool respuesta = false;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conexion.Conexionc;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Idioma(Nombre) VALUES(@Idioma)";
                command.Parameters.AddWithValue("@Idioma", idioma);

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
        /// select de idioma por id
        /// </summary>
        /// <param name="id">id de idioma</param>
        /// <returns>Idioma</returns>
        public Idioma Select(int id)
        {
            Idioma result = null;
            try
            {
                if (conexion.conectarServer())
                {
                    string sql = @"SELECT* FROM Idioma WHERE ID = " + id + "; ";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var list = new List<Idioma>();
                            while (reader.Read())
                            {
                                Idioma i = new Idioma();
                                i.setID(reader.GetByte(0));
                                i.setNom(reader.GetString(1));
                                result = i;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                String MostrarError = "Mensaje de la excepcio: " + ex.Message.ToString();
            }
            finally
            {
                conexion.desconectar();
            }
            return result;
        }


        /// <summary>
        /// select todos los idiomas
        /// </summary>
        /// <returns>lista de idiomas</returns>
        public Idioma[] Selectall()
        {
            Idioma[] lstIdioma = null;
            try
            {
                if (conexion.conectarServer())
                {
                    string sql = @"SELECT* FROM Idioma;";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var list = new List<Idioma>();
                            while (reader.Read())
                            {
                                Idioma i = new Idioma();
                                i.setID(reader.GetByte(0));
                                i.setNom(reader.GetString(1));
                                list.Add(i);
                            }
                            lstIdioma = list.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                String MostrarError = "Mensaje de la excepcio: " + ex.Message.ToString();
            }
            finally
            {
                conexion.desconectar();
            }
            return lstIdioma;
        }
    }
}