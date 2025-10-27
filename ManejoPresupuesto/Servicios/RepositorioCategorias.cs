using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{

    public interface IRepositorioCategorias
    {
        Task Crear(Categoria categoria);
    }

    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly string ConnectionString;

        public RepositorioCategorias(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Categoria categoria)
        {
            using var connection = new SqlConnection(ConnectionString);

            var Id = await connection.QuerySingleAsync<int>(@"
                                           INSERT INTO Categorias (Nombre, TipoOperacionId, UsuarioId)
                                           Values (@Nombre, @TipoOperacionId, @UsuarioId);
                                           
                                           SELECT SCOPE_IDENTITY();
                                           ", categoria);

            categoria.Id = Id;
        }
    }
}
