using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Moq;
using NUnit.Framework;
using WebApi1.Models;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi1.Test
{
    public class ClientesControllerTest
    {
        private TestServer _server;
        private HttpClient _client;
        private const string recursoClientes = "/api/clientes";
        private Mock<IClientesService> _servicioClientesMock;
        
        [SetUp]
        public void Setup(){ 
            _servicioClientesMock = new Mock<IClientesService>();
            _server = new TestServer(new WebHostBuilder()
                .ConfigureTestServices( s => s.Add( 
                    new ServiceDescriptor(typeof(IClientesService), _servicioClientesMock.Object)))
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public void DeberiaExistirRecursoClientes()
        {            
            var request = _client.GetAsync(recursoClientes);
            Assert.AreNotEqual(HttpStatusCode.NotFound, request.Result.StatusCode);
        }

        [Test]        
        public void DeberiaObtenerClientes(){
            var unClienteValido = new Cliente {
                    Identificador = 1,
                    Nombre = "Juan",
                    Apellido = "Perez",
                };
            var clientes = new Cliente [] { unClienteValido };
            _servicioClientesMock
                .Setup( m => m.ObtenerClientes() )
                .Returns(clientes);
            
            var request = _client.GetAsync(recursoClientes);
            
            Assert.AreEqual(HttpStatusCode.OK, request.Result.StatusCode);
            _servicioClientesMock.Verify ( (m) => m.ObtenerClientes(), Times.Once() );
            var respuestaClientes = DeserializarClientes<IList<Cliente>>(request.Result.Content);
            Assert.AreEqual(1, respuestaClientes.Count);
            Assert.AreEqual(unClienteValido, respuestaClientes[0]);
        }        

        [Test]
        public void DeberiaObtenerUnCliente(){
            var identificadorCliente = 1234;
            var unClienteValido = new Cliente {
                    Identificador = identificadorCliente,
                    Nombre = "Juan",
                    Apellido = "Perez",
                };
            _servicioClientesMock
                .Setup( m => m.ObtenerCliente(identificadorCliente) )
                .Returns(unClienteValido);
            
            var request = _client.GetAsync($"{recursoClientes}/{identificadorCliente}");
            
            Assert.AreEqual(HttpStatusCode.OK, request.Result.StatusCode);
            _servicioClientesMock.Verify ( (m) => m.ObtenerCliente(identificadorCliente), Times.Once() );
            var respuestaCliente = DeserializarClientes<Cliente>(request.Result.Content);
            Assert.AreEqual(unClienteValido, respuestaCliente);
        }

        [Test]        
        public void NoDeberiaObtenerClientes(){            
            var clientes = new Cliente [] { };
            _servicioClientesMock
                .Setup( m => m.ObtenerClientes() )
                .Returns(clientes);
            
            var request = _client.GetAsync(recursoClientes);
            
            Assert.AreEqual(HttpStatusCode.NoContent, request.Result.StatusCode);
            _servicioClientesMock.Verify ( (m) => m.ObtenerClientes(), Times.Once());
            Assert.IsEmpty(request.Result.Content.ReadAsStringAsync().Result);
        }

        [Test]
        public void NoDeberiaObtenerUnCliente(){
            var identificadorCliente = 1234;
            var otroIdentificadorCliente = identificadorCliente+1;
            var unClienteValido = new Cliente {
                    Identificador = identificadorCliente,
                    Nombre = "Juan",
                    Apellido = "Perez",
                };
            _servicioClientesMock
                .Setup( m => m.ObtenerCliente(identificadorCliente) )
                .Returns(unClienteValido);
            
            var request = _client.GetAsync($"{recursoClientes}/{otroIdentificadorCliente}");
            
            Assert.AreEqual(HttpStatusCode.NotFound, request.Result.StatusCode);
            _servicioClientesMock.Verify ( (m) => m.ObtenerCliente(otroIdentificadorCliente), Times.Once());
        }

        private T DeserializarClientes<T>(HttpContent content){
            var options = new JsonSerializerOptions { 
                PropertyNameCaseInsensitive = true
            };            
            return JsonSerializer.Deserialize<T>(content.ReadAsStringAsync().Result, options);
        }         
    }
}