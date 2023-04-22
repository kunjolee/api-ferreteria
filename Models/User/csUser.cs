

using System.Data;
using System.Data.SqlClient;
using static api_ferreteria.Models.article.csArticleStructure;
using static api_ferreteria.Models.User.csUserStructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_ferreteria.Models.User

{
    public class csUser
    {
        /* CRUD */
        //3 queries
        // insert into table (attribute1, attribute2) values (attribute1, attribute2)

        // update table set attribute1 = 'new value', attribute2 = 'new vaue'
        // delete from table where attribute1 = "una condicion"
        // delete from User where IdUser = 1

        //string query = "update Articulo " +
        //"set Nombre = '" + nombre + "', Stock = " + stock + ", Precio = " + precio + " " +
        //"where IdArticulo = " + idArticulo + " ";

        //"delete from Articulo where IdArticulo = "+idArticulo+"";




        //POST
        public responseUser insertUser(int idUsuario, string correo, string telefono, string direccion, string fechaNacimiento)
        {
            responseUser result = new responseUser();
            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "insert into Usuario(Correo, Telefono, Direccion, FechaNacimiento )" +
                    " values( '" + correo + "', '" + telefono + "', '" + direccion + "', '" + fechaNacimiento + "' )";



                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();
                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }


                result.response_description = "User saved succesfully";


            }
            catch (Exception error)
            {
                result.response = 0;
                result.response_description = "Error saving user: " + error.Message.ToString();
            }


            cn.Close();

            return result;
        }

        public responseUser updateUser(int idUsuario, string correo, string telefono, string direccion, string fechaNacimiento)
        {
            responseUser result = new responseUser();
            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                /*string query = "update Usuario " + 
                    "set Correo = '"+ correo + "', Telefono = "+ telefono + ", Direccion = "+ direccion +", FechaNacimiento = "+fechaNacimiento + " " +
                     "where IdUsuario = " + idUsuario + " ";*/

                string query = "update Usuario " +
                "set Correo = '" + correo + "', Telefono = '" + telefono + "', Direccion = '" + direccion + "', FechaNacimiento = '" + fechaNacimiento + "' " +
                "where IdUsuario = " + idUsuario + " ";

                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();
                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }


                result.response_description = "User updated succesfully";


            }
            catch (Exception error)
            {
                result.response = 0;
                result.response_description = "Error updating user: " + error.Message.ToString();
            }


            cn.Close();

            return result;
        }


        public responseUser deleteUser(int idUsuario)
        {

            responseUser result = new responseUser();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "delete from Usuario where idUsuario = " + idUsuario + "";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "User deleted succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error deliting User: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }


        //DataSet es una tabla de datos (tiene que tener los mismos campos que mi tabla de mi DB)
        public DataSet listUsers()
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from Usuario";

                SqlCommand cmd = new SqlCommand(query, cn);

                //recibe de manera temporal a memoria temporal todos los registros de una tabla. Es una tabla temporal
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //vamos a llenar la tabla temporal dataAdapter a una tabla completa "dsi-DataSet"
                da.Fill(dsi);
                dsi.Tables[0].TableName = "Users"; //agregar un nombre a la tabla
                return dsi;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public DataSet listUsersById(int idUsuario)
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from Usuario where idUsuario=" + idUsuario + "";

                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "User";
                return dsi;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}



