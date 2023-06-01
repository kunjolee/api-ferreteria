using System;
namespace api_ferreteria.Models.FacturaDetalle
{
    public class csFacturaDetalleStructure
    {
        //crear el json que permita recibir los parametros del cliente

        public class requestFacturaDetalle
        {
            public int idFacturaDetalle { get; set; }
            public int idDetalle { get; set; }
            public int idFactura { get; set; }
            public int idArticulo { get; set; }
            public int cantidad { get; set; }
            public double subtotal { get; set; }

        }


        // respuesta del articulo, sera una clase

        public class responseFacturaDetalle
        {
            public int response { get; set; } //-> 0 | 1
            public string response_description { get; set; } //-> message success | failed
        }


        //cada request es el body que recibo de postman	
        public class requestDeleteFacturaDetalle
        {
            public int idFacturaDetalle { get; set; }
        }
    }
}

