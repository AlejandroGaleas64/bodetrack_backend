using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BodeTrack.DataAccess.Repositories.Inventario
{
    public class LotesRepository : IRepository<tbLotes>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbLotes Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbLotes item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbLotes> List()
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            return db.Query<tbLotes>(ScriptDatabase.Lotes_Listar, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbLotes item)
        {
            throw new NotImplementedException();
        }
    }
}