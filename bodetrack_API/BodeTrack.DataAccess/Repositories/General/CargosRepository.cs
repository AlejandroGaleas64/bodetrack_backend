using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BodeTrack.DataAccess.Repositories.General
{
    public class CargosRepository : IRepository<tbCargos>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbCargos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbCargos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbCargos> List()
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            return db.Query<tbCargos>(ScriptDatabase.Cargos_Listar, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbCargos item)
        {
            throw new NotImplementedException();
        }
    }
}