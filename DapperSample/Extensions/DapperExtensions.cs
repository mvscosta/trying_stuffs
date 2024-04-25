using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace DapperSample.Extensions
{
    public static class DapperExtensions
    {
        /// <summary>
        /// Create a SqlDataRecord from a dictionary of properties
        /// </summary>
        /// <param name="propertiesDictionary"></param>
        /// <returns></returns>
        public static IEnumerable<SqlDataRecord> CreateSqlDataRecord(Dictionary<string, object> propertiesDictionary)
        {
            static SqlDbType GetSqlType(object val) => new SqlParameter("placeholder", val).SqlDbType;

            var metaDataTable = new List<SqlMetaData>();

            foreach (var prop in propertiesDictionary)
            {
                var dbType = GetSqlType(prop.Value);
                if (dbType is SqlDbType.NVarChar or SqlDbType.VarChar or SqlDbType.Char or SqlDbType.NChar)
                {
                    dbType = SqlDbType.Text;
                }

                var metaData = new SqlMetaData(prop.Key, dbType);
                metaDataTable.Add(metaData);
            }

            var dataRecord = new SqlDataRecord([.. metaDataTable]);
            for (var i = 0; i < dataRecord.FieldCount; i++)
            {
                dataRecord.SetValue(i, propertiesDictionary[metaDataTable[i].Name]);
            }

            return [dataRecord];
        }
    }
}