using System;
using System.Data.SqlClient;
using System.Data;
using static api_ferreteria.Models.article.csArticleStructure;


namespace api_ferreteria.Models.article
{
	public class csArticle
	{
        //esta clase tendra el CRUD


        public responseArticle insertArticle(int idArticulo, string nombre, int stock, double precio)
        {

            responseArticle result = new responseArticle();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);



                string query = "insert into Articulo(Nombre,Stock, Precio) values " +
                    " ('" + nombre + "', " + stock + ", " + precio + " )";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0
                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }
                result.response_description = "Article saved succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error saving article: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        public responseArticle updateArticle(int idArticulo, string nombre, int stock, double precio)
        {

            responseArticle result = new responseArticle();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "update Articulo " +
                "set Nombre = '"+ nombre +"', Stock = "+stock+", Precio = "+precio+" " +
                "where IdArticulo = "+idArticulo+" ";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Article updated succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error updating article: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }
        
        public responseArticle deleteArticle(int idArticulo)
        {

            responseArticle result = new responseArticle();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "delete from Articulo where IdArticulo = "+idArticulo+"";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Article deleted succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error deliting article: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        //DataSet es una tabla de datos (tiene que tener los mismos campos que mi tabla de mi DB)
        public DataSet listArticles() {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from Articulo";

                SqlCommand cmd = new SqlCommand(query, cn);

                //recibe de manera temporal a memoria temporal todos los registros de una tabla. Es una tabla temporal
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //vamos a llenar la tabla temporal dataAdapter a una tabla completa "dsi-DataSet"
                da.Fill(dsi);
                dsi.Tables[0].TableName = "Articles"; //agregar un nombre a la tabla
                return dsi;

            }catch(Exception e)
            {
                return null; 
            }
        }
        public DataSet listArticlesById(int idArticulo) {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from Articulo where idArticulo="+idArticulo+"";

                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "Article"; 
                return dsi;

            }catch(Exception e)
            {
                return null; 
            }
        }
    }
}

