using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IAteneav2.Clases;
using System.Data.SqlClient;
using System.Data;

namespace IAteneav2.Models
{
    public class MDifinidoresDeCategoria
    {
        Logic.Conexion conexion = new Logic.Conexion();

        public LinkedList<Clases.DifinidorDeCategoria> getDifinidoresDeCategoria()
        {
            bool isConected = conexion.conectarServer();
            LinkedList<Clases.DifinidorDeCategoria> lista = new LinkedList<Clases.DifinidorDeCategoria>();
            try
            {
                if (isConected)
                {
                    // select * from Palabra where ID = 0;
                    string sql = @"select * from PalabraDCat;";
                    using (var command = new SqlCommand(sql, conexion.Conexionc))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Clases.DifinidorDeCategoria difinidorDeCategoria = new Clases.DifinidorDeCategoria(reader.GetInt32(0), reader.GetInt32(1));
                                lista.AddLast(difinidorDeCategoria);
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

        public bool agregarDifinidorDeCategoria(int palabra, int categoria)
        {
            bool isConected = conexion.conectarServer();
            bool respuesta = false;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conexion.Conexionc;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO PalabraDCat(Palabra,Categoria) VALUES(@Nombre,@Categoria)";
                command.Parameters.AddWithValue("@Nombre", palabra);
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
    }
}