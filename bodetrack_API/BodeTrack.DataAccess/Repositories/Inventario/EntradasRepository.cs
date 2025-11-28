using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BodeTrack.DataAccess.Repositories.Inventario
{
    public class EntradasRepository : IRepository<tbEntradas>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEntradas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEntradas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEntradas> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbEntradas item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus InsertarEntrada(tbEntradas entrada, string jsonDetalles)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Entr_NumeroFactura", entrada.Entr_NumeroFactura);
            parameter.Add("@Entr_Observacion", entrada.Entr_Observacion);
            parameter.Add("@Entr_Creacion", entrada.Entr_Creacion);
            parameter.Add("@Entr_FechaCreacion", DateTime.Now);
            parameter.Add("@JsonDetalles", jsonDetalles);

            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<RequestStatus>(
                ScriptDatabase.Entrada_Insertar,
                parameter,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}