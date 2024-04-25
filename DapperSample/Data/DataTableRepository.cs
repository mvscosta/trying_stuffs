using Dapper;

namespace DapperSample.Data
{
    public class DataTableRepository : IDataTableRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DbOperationRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<bool> RunProcedure(Model dbEntity)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();

            var parameters = new 
            var result = await connection.ExecuteAsync(
                @"", parameters);
            return result > 0;
        }
    }
}
