namespace WebApi1.Models {
    public interface IClientesService
    {
        Cliente[] ObtenerClientes();
        Cliente ObtenerCliente(int identificadorCliente);
    }
}