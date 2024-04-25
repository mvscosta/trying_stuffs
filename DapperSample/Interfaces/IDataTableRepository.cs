using System.Data;

namespace DapperSample.Interfaces
{
    public interface IDataTableRepository
    {
        public Task<IDbConnection> RunProcedure();
    }
}