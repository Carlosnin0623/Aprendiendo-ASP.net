using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{

    public interface IRepositorioTiposCuentas
    {
        Task Crear(TipoCuenta tipoCuenta);

        Task<bool> Existe(string nombre, int usuarioId);

        Task<IEnumerable<TipoCuenta>> Obtener(int UsuarioId);


        Task Actualizar(TipoCuenta tipoCuenta);

        Task<TipoCuenta> ObtenerPorId(int id, int usuarioId);

        Task Borrar(int id);

        Task Ordenar(IEnumerable<TipoCuenta> tipoCuentasOrdenados);
    }

    public class RepositorioTiposCuentas : IRepositorioTiposCuentas
    {

        private readonly string connectionString;

        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);

            var id = await connection.QuerySingleAsync<int>("TiposCuentas_Insertar", new {UsuarioId = tipoCuenta.UsuarioId,
            Nombre = tipoCuenta.Nombre}, commandType: System.Data.CommandType.StoredProcedure);

            tipoCuenta.Id = id;
        }

        public async Task<bool> Existe(string nombre, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);

            var existe = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1 FROM TiposCuentas 
                                                                        where Nombre = @Nombre 
                                                                        and UsuarioId = @UsuarioId;", 
                                                                        new {nombre, usuarioId});

            return existe == 1;
        }

        public async Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<TipoCuenta>(@"SELECT Id, Nombre, Orden 
                                                           from TiposCuentas
                                                           where UsuarioId = @UsuarioId
                                                           ORDER BY Orden", new { usuarioId });
        }


        public async Task Actualizar(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(@"UPDATE TiposCuentas
                                           SET Nombre = @Nombre
                                           WHERE Id = @Id", tipoCuenta);
        }

        public async Task<TipoCuenta> ObtenerPorId(int id, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<TipoCuenta>(@"SELECT Id, Nombre, Orden
                                                                         FROM TiposCuentas
                                                                         WHERE Id = @Id
                                                                         AND UsuarioId = @UsuarioId",
                                                                         new { id, usuarioId });

        }

        public async Task Borrar(int id)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(@"DELETE TiposCuentas WHERE Id = @Id", new { id });

        }


        public async Task Ordenar(IEnumerable<TipoCuenta> tipoCuentasOrdenados)
        {

            var query = "UPDATE TiposCuentas SET Orden = @Orden WHERE Id = @Id";

            using var connection = new SqlConnection(connectionString);

            /* Aplicando multiples querys a la base de datos con dapper */

            await connection.ExecuteAsync(query, tipoCuentasOrdenados);
        }
    }
}
