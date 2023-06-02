using System;
namespace api_ferreteria.Models.Empleado
{
    public class csEmpleadoStructure
    {
        //crear el json que permita recibir los parametros del cliente

        public class requestEmpleado
        {
            public int idEmpleado { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int idUsuario { get; set; }

        }


        // respuesta del Empleado, sera una clase

        public class responseEmpleado
        {
            public int response { get; set; } //-> 0 | 1
            public string response_description { get; set; } //-> message success | failed
        }

        public class responseEmpleadoWithId
        {
            public int response { get; set; } //-> 0 | 1
            public string response_description { get; set; } //-> message success | failed
            public int idEmpleado { get; set; }
        }

        //cada request es el body que recibo de postman	
        public class requestDeleteEmpleado
        {
            public int idEmpleado { get; set; }
        }
    }
}

