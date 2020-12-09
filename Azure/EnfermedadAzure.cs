using System;
using AppiEnfermedades.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace AppiEnfermedades.Azure
{
    public class EnfermedadAzure
    {
        // ruta
        static string connectionString = @"Server=LAPTOP-SEH6HDEK\SQLEXPRESS;Database=Appi;Trusted_Connection=True;";

        private static List<Enfermedad> enfermedades;
        //Obtener Todas las Categorias

        public static List<Enfermedad> ObtenerEnfermedades()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var comando = AbrirConexionSqlEnfermedad(sqlConnection);

                var dataTable = LlenadoTabla(comando);

                return ListarEnfermedad(dataTable);

            }

        }

        public static int AgregarEnfermedad(Enfermedad enfermedad)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Insert into Enfermedad(nombre_enfermedad) values (@nombre_enfermedad)";

                sqlCommand.Parameters.AddWithValue("@nombre_enfermedad", enfermedad.NombreEnfermedad);
           


                try
                {
                    sqlConnection.Open();

                    resultado = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                return resultado;
            }

        }


        public static int ActualizarEnfermedad(Enfermedad enfermedad)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "UPDATE Enfermedad SET nombre_enfermedad = @nombre_enfermedad where id_enfermedad = @id_enfermedad" ;

                sqlCommand.Parameters.AddWithValue("@nombre_enfermedad", enfermedad.NombreEnfermedad);
                sqlCommand.Parameters.AddWithValue("@id_enfermedad", enfermedad.IdEnfermedad);



                try
                {
                    sqlConnection.Open();

                    resultado = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                return resultado;
            }

        }

        public static int AgregarEnfermedadporNombre(string enfermedad)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Insert into Enfermedad(nombre_enfermedad) values (@nombre_enfermedad)";

                sqlCommand.Parameters.AddWithValue("@nombre_enfermedad", enfermedad);



                try
                {
                    sqlConnection.Open();

                    resultado = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                return resultado;
            }

        }

        public static int EliminarEnfermedad(string nombre_enfermedad)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Delete from Enfermedad where nombre_enfermedad = @nombre_enfermedad";

                sqlCommand.Parameters.AddWithValue("@nombre_enfermedad", nombre_enfermedad);

                try
                {
                    sqlConnection.Open();

                    resultado = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                return resultado;
            }

        }







        public static SqlCommand AbrirConexionSqlEnfermedad(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
            sqlCommand.CommandText = "select * from Enfermedad";
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

        public static List<Enfermedad> ListarEnfermedad(DataTable dataTable)
        {
            enfermedades = new List<Enfermedad>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Enfermedad enfermedad = new Enfermedad();
                enfermedad.IdEnfermedad = int.Parse(dataTable.Rows[i]["id_enfermedad"].ToString());
                enfermedad.NombreEnfermedad = dataTable.Rows[i]["nombre_enfermedad"].ToString();
                enfermedades.Add(enfermedad);

            }
            return enfermedades;
        }

    }
}