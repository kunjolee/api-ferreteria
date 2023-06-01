using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting.Server;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static api_ferreteria.Models.FormaPago.csFormaPagoStructure;
using System.Data;

namespace api_ferreteria.Models.FormaPago
{
	public class csFormaPago
	{
		//CRUD methods

		public responsePagoWithId insertFormaPago (int idPago, string tipo)
		{
            responsePagoWithId result = new responsePagoWithId();
			string connection = "";
			SqlConnection cn = null;


            try
			{
				connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
				cn = new SqlConnection(connection);

				string query = "insert into FormaPago(Tipo) OUTPUT inserted.idPago values " +
					"('" + tipo + "' ) ";

				cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.idPago = Convert.ToInt32(cmd.ExecuteScalar());
                result.response = 1;

                result.response_description = "Forma pago saved successfully";

               
            }
            catch (Exception e)
            {
                result.response = 0;
				result.response_description = "Error saving forma de pago: " + e.Message.ToString();
            }

            cn.Close();

            return result;
		}


    public responseFormaPago updateFormaPago(int idPago, string tipo)
    {
        responseFormaPago result = new responseFormaPago();
        string connection = "";
        SqlConnection cn = null;


        try
        {
            connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
            cn = new SqlConnection(connection);

                string query = "update FormaPago " +
                   "set Tipo = '" + tipo + "' " +
                   "where idPago = " + idPago + " ";

                cn.Open();

            SqlCommand cmd = new SqlCommand(query, cn);

            result.response = cmd.ExecuteNonQuery(); //-> 1 | 0

            if (result.response == 0)
            {
                throw new Exception("Something went wrong");
            }

            result.response_description = "Forma pago updated successfully";


        }
        catch (Exception e)
        {
            result.response = 0;
            result.response_description = "Error updating forma de pago: " + e.Message.ToString();
        }

        cn.Close();

        return result;
    }


        public responseFormaPago deleteFormaPago(int idPago)
        {
            responseFormaPago result = new responseFormaPago();
            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);

                string query = "delete from FormaPago where idPago = " + idPago + "";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery(); //-> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Forma pago deleted successfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error deleting forma de pago: " + e.Message.ToString();
            }

            cn.Close();

            return result;
        }

        public DataSet listFormaPago()
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from FormaPago";

                SqlCommand cmd = new SqlCommand(query, cn);

                //recibe de manera temporal a memoria temporal todos los registros de una tabla. Es una tabla temporal
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //vamos a llenar la tabla temporal dataAdapter a una tabla completa "dsi-DataSet"
                da.Fill(dsi);
                dsi.Tables[0].TableName = "FormaPago"; //agregar un nombre a la tabla
                cn.Close();
                return dsi;

            }
            catch (Exception e)
            {
                cn.Close();
                return null;
            }
        }
        public DataSet listFormaPagoById(int idPago)
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select * from FormaPago where idPago=" + idPago + "";

                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "FormaPago";
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

