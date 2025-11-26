using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BodeTrack.DataAccess.Repositories.General
{
    public class EmpleadosRepository : IRepository<tbEmpleados>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEmpleados> List()
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            return db.Query<tbEmpleados>(ScriptDatabase.Empleados_Listar, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbEmpleados item)
        {
            throw new NotImplementedException();
        }
    }
}