using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BodeTrack.DataAccess.General
{
    public class DepartamentoRepository : IRepository<tbDepartamentos>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbDepartamentos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbDepartamentos> List()
        {
            var parameter = new DynamicParameters();
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            var result = db.Query<tbDepartamentos>(ScriptDatabase.Departamentos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbDepartamentos item)
        {
            throw new NotImplementedException();
        }
    }
}