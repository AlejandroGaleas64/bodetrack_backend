using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BodeTrack.DataAccess.Repositories.General
{
    public class ArticulosRepository : IRepository<tbArticulos>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbArticulos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbArticulos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbArticulos> List()
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            return db.Query<tbArticulos>(ScriptDatabase.Articulos_Listar, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbArticulos item)
        {
            throw new NotImplementedException();
        }
    }
}