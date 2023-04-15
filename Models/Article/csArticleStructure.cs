using System;
namespace api_ferreteria.Models.article
{
	public class csArticleStructure
	{
		//crear el json que permita recibir los parametros del cliente

		public class requestArticle
		{
			public int idArticulo { get; set; }
			public string nombre { get; set; }
			public int stock { get; set; }
			public double precio { get; set; }

		}


		// respuesta del articulo, sera una clase

		public class responseArticle
		{
			public int response { get; set; } //-> 0 | 1
			public string response_description { get; set; } //-> message success | failed
		}

		//cada request es el body que recibo de postman	
		public class requestDeleteArticle
		{
			public int idArticulo { get; set; }
		}
	}
}

