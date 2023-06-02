using System;
using System.Data.SqlClient;
using System.Data;
using static api_ferreteria.Models.Empleado.csEmpleadoStructure;


namespace api_ferreteria.Models.Empleado
{
    public class csEmpleado
    {
        //esta clase tendra el CRUD


        public responseEmpleadoWithId insertEmpleado(string nombre, string apellido, int idUsuario)
        {

            responseEmpleadoWithId result = new responseEmpleadoWithId();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);



                string query = "insert into Empleado(Nombre,Apellido, idUsuario) OUTPUT inserted.idEmpleado values " +
                    " ('" + nombre + "', '" + apellido + "', " + idUsuario + " )";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);
                result.idEmpleado = Convert.ToInt32(cmd.ExecuteScalar());
                result.response = 1;
                result.response_description = "Empleado saved succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error saving Empleado: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        public responseEmpleado updateEmpleado(int idEmpleado, string nombre, string apellido, int idUsuario)
        {

            responseEmpleado result = new responseEmpleado();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "update Empleado " +
                "set Nombre = '" + nombre + "', Apellido = '" + apellido + "', idUsuario = " + idUsuario + " " +
                "where IdEmpleado = " + idEmpleado + " ";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Empleado updated succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error updating Empleado: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        public responseEmpleado deleteEmpleado(int idEmpleado)
        {

            responseEmpleado result = new responseEmpleado();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "delete from Empleado where IdEmpleado = " + idEmpleado + "";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Empleado deleted succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error deliting Empleado: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        //DataSet es una tabla de datos (tiene que tener los mismos campos que mi tabla de mi DB)
        public DataSet listEmpleados()
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select " +
                    " e.idEmpleado, e.Nombre, e.Apellido, e.idUsuario, " +
                    " u.Correo " +
                    " from Empleado e" +
                    " join Usuario u on u.idUsuario = e.idUsuario ";

                SqlCommand cmd = new SqlCommand(query, cn);

                //recibe de manera temporal a memoria temporal todos los registros de una tabla. Es una tabla temporal
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //vamos a llenar la tabla temporal dataAdapter a una tabla completa "dsi-DataSet"
                da.Fill(dsi);
                dsi.Tables[0].TableName = "Empleados"; //agregar un nombre a la tabla
                cn.Close();
                return dsi;

            }
            catch (Exception e)
            {
                cn.Close();
                return null;
            }
        }
        public DataSet listEmpleadosById(int idEmpleado)
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from Empleado where idEmpleado=" + idEmpleado + "";

                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "Empleado";
                cn.Close();
                return dsi;

            }
            catch (Exception e)
            {
                cn.Close();
                return null;
            }
        }
    }
}

