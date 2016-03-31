using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IAteneav2.Clases;
using System.Data.SqlClient;
using System.Data;

namespace IAteneav2.Models
{
    public class MPalabras
    {
        Logic.Conexion conexion = new Logic.Conexion();

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
    }
}