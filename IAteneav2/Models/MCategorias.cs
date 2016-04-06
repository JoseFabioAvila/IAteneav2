using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IAteneav2.Clases;
using System.Data.SqlClient;
using System.Data;

namespace IAteneav2.Models
{
    public class MCategorias
    {
        Logic.Conexion conexion = new Logic.Conexion();

        public LinkedList<Clases.Categoria> getCategorias()
        {
            bool isConected = conexion.conectarServer();
            LinkedList<Clases.Categoria> lista = new LinkedList<Clases.Categoria>();
            try
            {
                if (isConected)
                {
                    // select * from Palabra where ID = 0;
                    string sql = @"select * from Categoria;";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Clases.Categoria categoria = new Clases.Categoria(reader.GetInt32(0), reader.GetString(1));
                                lista.AddLast(categoria);
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

        public bool agregarCategoria(string categoria)
        {
            bool isConected = conexion.conectarServer();
            bool respuesta = false;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conexion.Conexionc;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Categoria(Nombre) VALUES(@Categoria)";
                command.Parameters.AddWithValue("@Categoria", categoria);

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

        // Seleccionar idioma
        public Categoria Select(int id)
        {
            Categoria result = null;
            try
            {
                if (conexion.conectarServer())
                {
                    string sql = @"SELECT* FROM Categoria WHERE ID = " + id + "; ";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var list = new List<Categoria>();
                            while (reader.Read())
                            {
                                Categoria i = new Categoria();
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

        public Categoria[] Selectall()
        {
            Categoria[] lstCat = null;
            try
            {
                if (conexion.conectarServer())
                {
                    string sql = @"SELECT* FROM Categoria;";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var list = new List<Categoria>();
                            while (reader.Read())
                            {
                                Categoria i = new Categoria();
                                i.setID(reader.GetByte(0));
                                i.setNom(reader.GetString(1));
                                list.Add(i);
                            }
                            lstCat = list.ToArray();
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
            return lstCat;
        }
    }
}