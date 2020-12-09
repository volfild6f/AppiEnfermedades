using System;
using AppiEnfermedades.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;


namespace AppiEnfermedades.Azure
{
    public class SintomaAzure
    {
        // ruta
        static string connectionString = @"Server=LAPTOP-SEH6HDEK\SQLEXPRESS;Database=Appi;Trusted_Connection=True;";

        private static List<Sintoma> sintomas;
        //Obtener Todas las Categorias

        public static List<Sintoma> ObtenerSintoma()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var comando = AbrirConexionSqlSintoma(sqlConnection);

                var dataTable = LlenadoTabla(comando);

                return ListarSintoma(dataTable);

            }

        }


        public static int AgregarSintomaporNombre(string nombre_sintoma , string descripcion )
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Insert into Sintoma(nombre_sintoma , detalle sintoma ) values (@nombre_sintoma , @detalle_sintoma )";

                sqlCommand.Parameters.AddWithValue("@nombre_sintoma", nombre_sintoma);
                sqlCommand.Parameters.AddWithValue("@detalle_sintoma", descripcion);



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

        public static int AgregarSintoma(Sintoma sintoma)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Insert into Sintoma(nombre_sintoma , detalle_sintoma) values (@nombre_sintoma , @detalle_sintoma)";

                sqlCommand.Parameters.AddWithValue("@nombre_sintoma", sintoma.NombreSintoma);
                sqlCommand.Parameters.AddWithValue("@detalle_sintoma", sintoma.DetalleSintoma);


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

        public static int ActualizarSintoma(Sintoma sintoma)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "UPDATE Sintoma SET nombre_sintoma = @nombre_sintoma , detalle_sintoma = @detalle_sintoma where id_sintoma= @id_sintoma";

                sqlCommand.Parameters.AddWithValue("@nombre_sintoma", sintoma.NombreSintoma);
                sqlCommand.Parameters.AddWithValue("@id_sintoma", sintoma.IdSintoma);
                sqlCommand.Parameters.AddWithValue("@detalle_sintoma", sintoma.DetalleSintoma);



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

        public static int EliminarSintoma (string nombre_sintoma)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Delete from Sintoma where nombre_sintoma = @nombre_sintoma";

                sqlCommand.Parameters.AddWithValue("@nombre_sintoma", nombre_sintoma);



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


        public static SqlCommand AbrirConexionSqlSintoma(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
            sqlCommand.CommandText = "select * from Sintoma";
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

        public static List<Sintoma> ListarSintoma(DataTable dataTable)
        {
            sintomas = new List<Sintoma>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Sintoma sintoma = new Sintoma();
                sintoma.IdSintoma = int.Parse(dataTable.Rows[i]["id_sintoma"].ToString());
                sintoma.NombreSintoma = dataTable.Rows[i]["nombre_sintoma"].ToString();
                sintoma.DetalleSintoma = dataTable.Rows[i]["detalle_sintoma"].ToString();
                sintomas.Add(sintoma);

            }
            return sintomas;
        }

    }
}

