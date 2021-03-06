﻿using System;
using System.Data.SqlClient;

namespace IAteneav2.Logic
{
    /// <summary>
    /// Clase que se encarga de crear, abrir y cerrar la conexion con la base de datos
    /// </summary>
    public class Conexion
    {

        private SqlConnection conexionc = new SqlConnection();
        //private String cadenaConexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=BD_ATENA;Integrated Security=True";
        private String cadenaConexion = @"Data Source=DESKTOP-DBO8CJO;Initial Catalog=BD_Conocimiento;Integrated Security=True";
        private String mostrarError = "";


        /// <summary>
        /// Muestreo de los errores
        /// </summary>
        public string MostrarError
        {
            get { return mostrarError; }
            set { mostrarError = value; }
        }

        /// <summary>
        /// get y set de la variable conecion
        /// </summary>
        public SqlConnection Conexionc
        {
            get
            {
                return conexionc;
            }

            set
            {
                conexionc = value;
            }
        }

        /// <summary>
        /// Abre la conexion a la base de datos
        /// </summary>
        /// <returns>True si la conexion fue exitosa, de lo contratio retorna false</returns>
        public bool conectarServer()
        {
            mostrarError = "";
            bool respuesta = false;
            try
            {
                conexionc.ConnectionString = cadenaConexion;
                conexionc.Open();
                respuesta = true;

            }
            catch (Exception exp)
            {
                respuesta = false;
                mostrarError = "No se ha podido conectar al servidor. Mensaje de la exepcion: " + exp.Message.ToString();
            }

            return respuesta;
        }


        /// <summary>
        /// Cierra la conexion con la base datos
        /// </summary>
        public void desconectar()
        {
            conexionc.Close();
        }
    }
}