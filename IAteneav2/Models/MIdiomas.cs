using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IAteneav2.Clases;
using System.Data.SqlClient;
using System.Data;

namespace IAteneav2.Models
{
    public class MIdiomas
    {
        Logic.Conexion conexion = new Logic.Conexion();

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
    }
}