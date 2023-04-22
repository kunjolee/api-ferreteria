
using System.Data;
using System.Data.SqlClient;
using static api_ferreteria.Models.article.csArticleStructure;
using static api_ferreteria.Models.Client.csClienteStructure;

namespace api_ferreteria.Models.Client
{
    public class csCliente
    {
        //MVC
        public responseClient insertClient(string nombre, string apellido, int DPI)
        {

            responseClient result = new responseClient();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);



                string query = "insert into Cliente(nombre,apellido,DPI) values " +
                    " ('" + nombre + "', '" + apellido + "', '" + DPI + "' )";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();
                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }
                result.response_description = "Client saved succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error saving Client: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }
        public responseClient updateClient( int IdCliente,string nombre, string apellido, int DPI)
        {

            responseClient result = new responseClient();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "update Cliente " +
                "set nombre = '" + nombre + "', apellido = '" + apellido + "', DPI = '" + DPI + "' where IdCliente = " +IdCliente+ " ";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Client updated succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error updating Client: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        public responseClient deleteClient(int idCliente)
        {

            responseClient result = new responseClient();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "delete from Cliente where IdCliente = " + idCliente + "";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Client deleted succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error deliting Client: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        //Tablas de datos

        public DataSet listClient()
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from Cliente";

                SqlCommand cmd = new SqlCommand(query, cn);

               
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "Client"; 
                return dsi;

            }
            catch (Exception e)
            {
                return null;
            }
        }


        public DataSet listArticlesById(int IdCliente)
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from Cliente where idCliente=" + IdCliente + "";

                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "Client";
                return dsi;

            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
