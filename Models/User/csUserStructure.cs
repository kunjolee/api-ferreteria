namespace api_ferreteria.Models.User
{
    public class csUserStructure
    {
        //crear una clase request y el response

        public class requestUser
        {
            public int idUsuario { get; set; }
            public  string correo { get; set; }
            public  string telefono { get; set; }
            public  string direccion { get; set; }
            public  string fechaNacimiento { get; set; }
        }

        public class responseUser
        {
            public int response { get; set; } //-> 0 | 1
            public string response_description { get; set; } //-> message success | failed
        }

        public class requestDelteUser 
        { 
            public int idUsuario { get; set; }

        }


    }
}

