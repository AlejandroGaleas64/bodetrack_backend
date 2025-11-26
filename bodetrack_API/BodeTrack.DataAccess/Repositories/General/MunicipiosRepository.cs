using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BodeTrack.DataAccess.Repositories.General
{
    public class MunicipiosRepository : IRepository<tbMunicipios>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbMunicipios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMunicipios> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbMunicipios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMunicipios> ListPorDepartamento(string Dept_Codigo)
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            var parameters = new { Dept_Codigo };
            return db.Query<tbMunicipios>(ScriptDatabase.Municipios_ListarPorDepartamento, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}