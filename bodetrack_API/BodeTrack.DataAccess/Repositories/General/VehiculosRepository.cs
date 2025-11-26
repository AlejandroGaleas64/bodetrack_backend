using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BodeTrack.DataAccess.Repositories.General
{
    public class VehiculosRepository : IRepository<tbVehiculos>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbVehiculos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbVehiculos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbVehiculos> List()
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            return db.Query<tbVehiculos>(ScriptDatabase.Vehiculos_Listar, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbVehiculos item)
        {
            throw new NotImplementedException();
        }
    }
}