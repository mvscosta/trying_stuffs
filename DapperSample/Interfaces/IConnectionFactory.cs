using System.Data;

namespace DapperSample.Interfaces
{
    public interface IDbConnectionFactory
    {
        public Task<IDbConnection> CreateConnectionAsync();
    }
}