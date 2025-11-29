using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BodeTrack.DataAccess.Repositories.General
{
    public class SucursalesRepository : IRepository<tbSucursales>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbSucursales Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbSucursales item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbSucursales> List()
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            return db.Query<tbSucursales>(ScriptDatabase.Sucursales_Listar, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbSucursales item)
        {
            throw new NotImplementedException();
        }
    }
}