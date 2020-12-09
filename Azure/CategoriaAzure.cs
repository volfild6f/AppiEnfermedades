using System;
using AppiEnfermedades.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace AppiEnfermedades.Azure
{
    public class CategoriaAzure
    {
        // ruta
        static string connectionString = @"Server=LAPTOP-SEH6HDEK\SQLEXPRESS;Database=Appi;Trusted_Connection=True;";

        private static List<Categoria> categorias;
        //Obtener Todas las Categorias

        public static List<Categoria> ObtenerCategorias()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var comando = AbrirConexionSqlCategoria(sqlConnection);

                var dataTable = LlenadoTabla(comando);

                return ListarCategoria(dataTable); 

            }
            
        }



        //Agregar Categoria

            public static int AgregarCategoria(Categoria categoria)
             {
                    int resultado = 0;

                    using(SqlConnection sqlConnection = new SqlConnection(connectionString) )
                    {
                        SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                        sqlCommand.CommandText = "Insert into Categoria(nombre_categoria) values (@nombre_categoria)";

                       sqlCommand.Parameters.AddWithValue("@nombre_categoria", categoria.NombreCategoria);


                        try
                        {
                            sqlConnection.Open();
                    
                            resultado= sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                         return resultado;
            }

            }

        public static int ActualizarCategoria(Categoria categoria)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "UPDATE Categoria SET nombre_categoria = @nombre_categoria where id_categoria = @id_categoria";

                sqlCommand.Parameters.AddWithValue("@nombre_categoria", categoria.NombreCategoria);
                sqlCommand.Parameters.AddWithValue("@id_categoria", categoria.IdCategoria);



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

        public static int EliminarCategoria(string nombre_categoria)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Delete from Categoria where nombre_categoria = @nombre_categoria";

                sqlCommand.Parameters.AddWithValue("@nombre_categoria", nombre_categoria);

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

        public static SqlCommand AbrirConexionSqlCategoria(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
            sqlCommand.CommandText = "select * from Categoria";
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

        public static List<Categoria> ListarCategoria(DataTable dataTable)
        {
            categorias = new List<Categoria>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Categoria categoria = new Categoria();
                categoria.IdCategoria = int.Parse(dataTable.Rows[i]["id_categoria"].ToString());
                categoria.NombreCategoria = dataTable.Rows[i]["nombre_categoria"].ToString();
                categorias.Add(categoria);

            }
            return categorias;
        }

    }
}
