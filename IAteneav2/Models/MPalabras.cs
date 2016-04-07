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
    /// Modelo de palabras
    /// </summary>
    public class MPalabras
    {
        //instancia de conexion
        Logic.Conexion conexion = new Logic.Conexion();

        // <summary>
        /// toma la lista de palabras
        /// </summary>
        /// <returns>lista de palabras</returns>
        public LinkedList<Clases.Palabra> getPalabras()
        {
            bool isConected = conexion.conectarServer();
            LinkedList<Clases.Palabra> lista = new LinkedList<Clases.Palabra>();
            try
            {
                if (isConected)
                {
                    // select * from Palabra where ID = 0;
                    string sql = @"select * from Palabra;";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Clases.Palabra palabra = new Clases.Palabra(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                                lista.AddLast(palabra);
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
        /// select all de palabras
        /// </summary>
        /// <returns>todas las palabras</returns>
        public Palabra[] Selectall()
        {
            Palabra[] lstPalabras = null;
            try
            {
                if (conexion.conectarServer())
                {
                    string sql = @"SELECT* FROM Palabra;";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var list = new List<Palabra>();
                            while (reader.Read())
                            {
                                Palabra i = new Palabra(); 
                                i.setId(reader.GetInt64(0));
                                i.setPalabra(reader.GetString(1));
                                i.setIdioma(reader.GetByte(2));
                                try
                                {
                                    Models.MCategorias mc = new Models.MCategorias();
                                    int x = reader.GetByte(4);
                                    i.Categoria = mc.Select(x);
                                }
                                catch (Exception ex)
                                {
                                    String MostrarError = "Mensaje de la excepcio: " + ex.Message.ToString();
                                }
                                list.Add(i);
                            }
                            lstPalabras = list.ToArray();
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
            return lstPalabras;
        }

        /// <summary>
        /// select de idioma por nombre
        /// </summary>
        /// <param name="nom">nombre de la palabra</param>
        /// <returns>la palabra</returns>
        public Palabra[] Select(String nom)
        {
            Palabra[] lstPalabras = null;
            try
            {
                if (conexion.conectarServer())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conexion.Conexionc;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM Palabra WHERE Nombre = @nom; ";
                        command.Parameters.AddWithValue("@nom", nom);

                        using (var reader = command.ExecuteReader())
                        {
                            var list = new List<Palabra>();
                            while (reader.Read())
                            {
                                Palabra i = new Palabra();
                                i.setId(reader.GetInt64(0));
                                i.setPalabra(reader.GetString(1));
                                i.setIdioma(reader.GetByte(2));
                                try
                                {
                                    Models.MCategorias mc = new Models.MCategorias();
                                    int x = reader.GetByte(4);
                                    i.Categoria = mc.Select(x);
                                }
                                catch (Exception ex)
                                {
                                    String MostrarError = "Mensaje de la excepcio: " + ex.Message.ToString();
                                }
                                list.Add(i);
                            }
                            lstPalabras = list.ToArray();
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
            return lstPalabras; 
        }

        /// <summary>
        /// verifica que exita la palabra en un idioma
        /// </summary>
        /// <param name="nom">palbra</param>
        /// <param name="idioma">id idioma</param>
        /// <returns>booleano que denota que existe o no</returns>
        public bool exist(String nom, int idioma)
        {
            bool res = false;
            try
            {
                if (conexion.conectarServer())
                {
                    //string sql = @"SELECT * FROM Palabra WHERE Nombre = " + nom + " AND  Idioma = "+idioma+"; ";

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conexion.Conexionc;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM Palabra WHERE Nombre = @nom AND  Idioma = @len; ";
                        command.Parameters.AddWithValue("@nom", nom);
                        command.Parameters.AddWithValue("@len", idioma);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                res = true;
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
            return res;
        }

        /// <summary>
        /// agrega palabras a la tabla de palabras
        /// </summary>
        /// <param name="palabra">palabra a gregar</param>
        /// <param name="i">idoma</param>
        /// <returns>booleano que denota exito</returns>
        public bool agregarPalabra(string palabra, Idioma i)
        {
            int idioma = i.ID;
            bool isConected = conexion.conectarServer();
            bool respuesta = false;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conexion.Conexionc;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Palabra(Nombre,Idioma) VALUES(@Palabra,@Idioma)";
                command.Parameters.AddWithValue("@Palabra", palabra);
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
        /// agrega palabras a la tabla de palabras
        /// </summary>
        /// <param name="palabra">plabra a agregar</param>
        /// <param name="idioma">idioma</param>
        /// <param name="categoria">categoria</param>
        /// <returns>booleano que denoa exito o error</returns>
        public bool agregarPalabra(string palabra, int idioma, int categoria)
        {
            bool isConected = conexion.conectarServer();
            bool respuesta = false;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conexion.Conexionc;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Palabra(Nombre,Idioma, Categoria) VALUES(@Palabra,@Idioma,@cat)";
                command.Parameters.AddWithValue("@Palabra", palabra);
                command.Parameters.AddWithValue("@Idioma", idioma);
                command.Parameters.AddWithValue("@cat", categoria);

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
        /// edita la categoria de una palabra por id
        /// </summary>
        /// <param name="id">id de palabra</param>
        /// <param name="cat">id categoria</param>
        /// <returns>booleano que denota exito o error</returns>
        public bool EditarCategoria(long id, int cat)
        {
            bool respuesta = false;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conexion.Conexionc;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Palabra SET Categoria = @nomv WHERE ID = @idv";
                command.Parameters.AddWithValue("@idv", id);
                command.Parameters.AddWithValue("@nomv", cat);

                try
                {
                    conexion.conectarServer();
                    int recordsAffected = command.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    String MostrarError = "Mensaje de la exepcion: " + ex.Message.ToString();
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