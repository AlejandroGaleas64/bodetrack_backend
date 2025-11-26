using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BodeTrack.DataAccess.Repositories.General
{
    public class EstadosCivilesRespository : IRepository<tbEstadosCiviles>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEstadosCiviles Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEstadosCiviles> List()
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            return db.Query<tbEstadosCiviles>(ScriptDatabase.EstadosCiviles_Listar, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }
    }
}