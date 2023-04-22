namespace api_ferreteria.Models.Client
{
    public class csClienteStructure
    {
        public class requesClient
        {
            public int idCliente { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int DPI { get; set; }

        }

        public class responseClient
        {
            public int response { get; set; } //-> 0 | 1
            public string response_description { get; set; } //-> message success | failed
        }

        public class requestDeleteCliente
        {
            public int idArticulo { get; set; }
        }

    }
}
