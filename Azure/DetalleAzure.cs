using System;
using AppiEnfermedades.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace AppiEnfermedades.Azure
{
    public class DetalleAzure
    {
        // ruta
        static string connectionString = @"Server=LAPTOP-SEH6HDEK\SQLEXPRESS;Database=Appi;Trusted_Connection=True;";

        private static List<DetalleEnfermedad> detalles;
        //Obtener Todas las Categorias

        public static List<DetalleEnfermedad> ObtenerDetalles()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var comando = AbrirConexionSqlDetalle(sqlConnection);

                var dataTable = LlenadoTabla(comando);

                return ListarDetalle(dataTable);

            }

        }

        



        public static SqlCommand AbrirConexionSqlDetalle(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
            sqlCommand.CommandText = "select * from Detalle_enfermedad";
            sqlConnection.Open();
            return sqlCommand;
        }

        public static DataTable LlenadoTabla(SqlCommand comando)
        {
            var dataTable = new DataTable();
            var dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public static List<DetalleEnfermedad> ListarDetalle(DataTable dataTable)
        {
            detalles = new List<DetalleEnfermedad>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DetalleEnfermedad detalle = new DetalleEnfermedad();
                detalle.IdDetalleEnfermedad = int.Parse(dataTable.Rows[i]["id_detalle_enfermedad"].ToString());
                detalle.IdEnfermedad = int.Parse(dataTable.Rows[i]["id_enfermedad"].ToString());
                detalle.IdCategoria = int.Parse(dataTable.Rows[i]["id_categoria"].ToString());
                detalle.IdSintoma= int.Parse(dataTable.Rows[i]["id_sintoma"].ToString());
                detalles.Add(detalle);

            }
            return detalles;
        }

    }
}