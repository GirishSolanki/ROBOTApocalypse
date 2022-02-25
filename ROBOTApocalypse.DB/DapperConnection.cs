using Dapper;
using System.Data;

namespace ROBOTApocalypse.DB
{
    public class DapperConnection : IDapperConnection
    {
        private readonly IDbConnection dbConnection;
        public DapperConnection(IDbConnection iDbConnection)
        {
            dbConnection = iDbConnection;
        }

        public List<T> Execute<T>(DapperProperty dapperProperty) where T : class
        {
            var result = dbConnection.Query<T>(dapperProperty.ProcName, dapperProperty.DynamicParameters, null, true, dapperProperty.CommandTimeout, CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}
