using System;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaBD
{
    public class conexion
    {

        string cadena = "Data Source=SEBASTIAN;Initial Catalog=PruebaNET; Integrated Security=True";
        public SqlConnection conectarbd = new SqlConnection();
        
        public conexion()
        {
            conectarbd.ConnectionString = cadena;
        }
        public void abrirConexion()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexion Abierta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la base de datos" + ex.Message);
            }
        }
        public void cerrarConexion()
        {
            conectarbd.Close();
        }
        public DataTable consultarDT(string SQL)
        {

            SqlCommand sqlCommand = new SqlCommand(SQL, conectarbd);
            SqlDataAdapter data = new SqlDataAdapter(sqlCommand);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }
        public int execute(string SQL)
        {

            SqlCommand sqlCommand = new SqlCommand(SQL, conectarbd);
            SqlDataAdapter data = new SqlDataAdapter(sqlCommand);

            return 1;
        }
    }
}
