using System;
namespace api_ferreteria.Models.Factura
{
    public class csFacturaStructure
    {
        //crear el json que permita recibir los parametros del cliente

        public class requestFactura
        {
            public int idFactura { get; set; }
            public string nombre { get; set; }
            public int idEmpleado { get; set; }
            public int idPago { get; set; }
            public string nit { get; set; }
            public string fecha { get; set; }
            public double total { get; set; }

        }


        // respuesta del articulo, sera una clase

        public class responseFactura
        {
            public int response { get; set; } //-> 0 | 1
            public string response_description { get; set; } //-> message success | failed
        }

        public class responseInsertFactura
        {
            public string response_description { get; set; } //-> message success | failed
            public int idFactura { get; set; }
        }

        //cada request es el body que recibo de postman	
        public class requestDeleteFactura
        {
            public int idFactura { get; set; }
        }
    }
}

