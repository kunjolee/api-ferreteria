using System;
using System.Data.SqlClient;
using System.Data;
using static api_ferreteria.Models.Factura.csFacturaStructure;


namespace api_ferreteria.Models.Factura
{
    public class csFactura
    {
        //esta clase tendra el CRUD


        public responseInsertFactura insertFactura(string nombre, int idEmpleado, int idPago, string nit, string fecha, double total)
        {

            responseInsertFactura result = new responseInsertFactura();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);



                string query = "insert into Factura(Nombre,idEmpleado, idPago, Nit, Fecha, Total) OUTPUT inserted.idFactura values " +
                    "('"+ nombre +"', "+idEmpleado+" , "+idPago+", '" + nit + "', '" + fecha + "', " + total + ")";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.idFactura = Convert.ToInt32(cmd.ExecuteScalar());

                result.response_description = "Factura saved succesfully";

            }
            catch (Exception e)
            {
                result.idFactura = 0;
                result.response_description = "Error saving Factura: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        public responseFactura updateFactura(int idFactura, string nombre, int idEmpleado, int idPago, string nit, string fecha, double total)
        {

            responseFactura result = new responseFactura();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "update Factura " +
                "set Nombre = '" + nombre + "', idEmpleado = " + idEmpleado + ", idPago = " + idPago + " , Nit = " + nit + ", Fecha = '" + fecha + "', total = " + total + " " +
                " where IdFactura = " + idFactura + " ";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Factura updated succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error updating Factura: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        public responseFactura deleteFactura(int idFactura)
        {

            responseFactura result = new responseFactura();

            string connection = "";
            SqlConnection cn = null;

            try
            {
                connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;
                cn = new SqlConnection(connection);


                string query = "delete from Factura where IdFactura = " + idFactura + "";

                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);

                result.response = cmd.ExecuteNonQuery();//ejecuta el query en la db -> 1 | 0

                if (result.response == 0)
                {
                    throw new Exception("Something went wrong");
                }

                result.response_description = "Factura deleted succesfully";

            }
            catch (Exception e)
            {
                result.response = 0;
                result.response_description = "Error deliting Factura: " + e.Message.ToString();
            }

            cn.Close();

            return result;

        }

        //DataSet es una tabla de datos (tiene que tener los mismos campos que mi tabla de mi DB)
        public DataSet listFactura()
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select " +
                " f.IdFactura, f.Nombre, f.Nit, f.Fecha, f.Total," +
                "" +
                " e.Nombre as 'Empleado'," +
                " fp.Tipo as 'FormaPago'" +
                "                                                   " +
                " from Factura f" +
                " join Empleado e on f.IdEmpleado = e.IdEmpleado" +
                " join FormaPago fp on f.IdPago = fp.IdPago" +
                " order by f.idFactura desc";



                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "Facturas"; 
                cn.Close();
                return dsi;

            }
            catch (Exception e)
            {
                cn.Close();
                return null;
            }
        }
        public DataSet listFacturaDetails(int idFactura)
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select " +
                "   f.idFactura, " +                
                "	fd.Cantidad," +
                "	fd.SubTotal," +
                "	a.Nombre as 'Articulo'," +
                "	a.Precio as 'ArticuloPrecio'" +
                " from Factura f" +
                " join FacturaDetalle fd on f.IdFactura = fd.IdFactura" +
                " join Articulo a on fd.IdArticulo = a.IdArticulo" +
                " where f.IdFactura = "+idFactura+" ";


                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "Factura";
                cn.Close();
                return dsi;


            }
            catch (Exception e)
            {
                cn.Close();
                return null;
            }
        }

        public DataSet listFacturaById(int idFactura)
        {

            DataSet dsi = new DataSet();
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["cnConection"].ConnectionString;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            try
            {
                string query = "select " +
                " f.IdFactura, f.Nombre, f.Nit, f.Fecha, f.Total," +
                "" +
                " e.Nombre as 'Empleado'," +
                " fp.Tipo as 'FormaPago'" +
                "                                                   " +
                " from Factura f" +
                " join Empleado e on f.IdEmpleado = e.IdEmpleado" +
                " join FormaPago fp on f.IdPago = fp.IdPago" +
                " where f.idFactura = "+idFactura+" ";


                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dsi);
                dsi.Tables[0].TableName = "Factura";
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

