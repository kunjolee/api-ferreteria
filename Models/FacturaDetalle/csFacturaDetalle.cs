using System;
using System.Data.SqlClient;
using System.Data;
using static api_ferreteria.Models.FacturaDetalle.csFacturaDetalleStructure;


namespace api_ferreteria.Models.FacturaDetalle
{
    public class csFacturaDetalle
    {
        //esta clase tendra el CRUD


        public responseFacturaDetalle insertFacturaDetalle(int idFactura, int idArticulo, int cantidad , double subtotal)
        {

            responseFacturaDetalle result = new responseFacturaDetalle();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);



                string query = "insert into FacturaDetalle(idFactura,idArticulo, Cantidad, SubTotal) values " +
                    "(" + idFactura+ ", " + idArticulo+ " , " + cantidad + ", " + subtotal + ")";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = Convert.ToInt32(cmd.ExecuteScalar());

                result.response_description = "FacturaDetalle saved succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error saving FacturaDetalle: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        public responseFacturaDetalle updateFacturaDetalle(int idFacturaDetalle, int idFactura, int idArticulo, int cantidad, double subtotal)
        {

            responseFacturaDetalle result = new responseFacturaDetalle();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "update FacturaDetalle " +
                "set idFactura = " + idFactura + ", idArticulo = " + idArticulo+ ", cantidad = " + cantidad + " , subtotal=" + subtotal+ " " +
                " where IdFacturaDetalle = " + idFacturaDetalle + " ";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "FacturaDetalle updated succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error updating FacturaDetalle: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        public responseFacturaDetalle deleteFacturaDetalle(int idFacturaDetalle)
        {

            responseFacturaDetalle result = new responseFacturaDetalle();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "delete from FacturaDetalle where IdFacturaDetalle = " + idFacturaDetalle + "";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "FacturaDetalle deleted succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error deliting FacturaDetalle: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        //DataSet es una tabla de datos (tiene que tener los mismos campos que mi tabla de mi DB)
        public DataSet listFacturaDetalle()
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from FacturaDetalle";

                SqlCommand cmd = new SqlCommand(query, cn);

                //recibe de manera temporal a memoria temporal todos los registros de una tabla. Es una tabla temporal
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //vamos a llenar la tabla temporal dataAdapter a una tabla completa "dsi-DataSet"
                da.Fill(dsi);
                dsi.Tables[0].TableName = "FacturaDetalles"; //agregar un nombre a la tabla
                cn.Close();
                return dsi;

            }
            catch (Exception e)
            {
                cn.Close();
                return null;
            }
        }
        public DataSet listFacturaDetalleById(int idFacturaDetalle)
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from FacturaDetalle where idFacturaDetalle=" + idFacturaDetalle + "";

                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "FacturaDetalle";
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

