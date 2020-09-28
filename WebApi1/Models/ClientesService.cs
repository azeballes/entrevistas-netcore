using System.Linq;

namespace WebApi1.Models {
    public class ClientesService : IClientesService
    {
        private static Cliente [] clientes = new Cliente [] {
            new Cliente { 
                Identificador = 1,
                Nombre = "Juan",
                Apellido = "Perez",
            },
            new Cliente { 
                Identificador = 2,
                Nombre = "José",
                Apellido = "Gonzalez",
            },
            new Cliente { 
                Identificador = 3,
                Nombre = "Manuel",
                Apellido = "García",
            },
        };
        public Cliente ObtenerCliente(int identificadorCliente) => 
            clientes.FirstOrDefault( c => c.Identificador == identificadorCliente);

        public Cliente[] ObtenerClientes() => clientes;
    }
}