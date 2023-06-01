using System;
namespace api_ferreteria.Models.FormaPago
{
	public class csFormaPagoStructure
	{
		//una clase que de la forma de nuestra request, y de nuestra response

		public class requestFormaPago
		{
			public int idPago { get; set; }
			public string tipo { get; set; }
		}

		public class responseFormaPago
		{
            public int response { get; set; } 
            public string response_description { get; set; } 
		}

        public class responsePagoWithId
        {
            public int response { get; set; } //-> 0 | 1
            public string response_description { get; set; } //-> message success | failed
            public int idPago { get; set; }
        }

        public class requestDeleteFormaPago
		{
			public int idPago { get; set; }
		}
	}
}


