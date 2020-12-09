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

