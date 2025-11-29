using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BodeTrack.DataAccess.Repositories.Inventario
{
    public class SalidasRepository : IRepository<tbSalidas>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbSalidas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbSalidas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbSalidas> List()
        {
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            return db.Query<tbSalidas>(ScriptDatabase.Salidas_Listar, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbSalidas item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus InsertarSalida(tbSalidas salida, string jsonDetalles)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sucs_Id", salida.Sucs_Id);
            parameter.Add("@Sali_UsuarioEnvia", salida.Sali_UsuarioEnvia);
            parameter.Add("@Vehi_Id", salida.Vehi_Id);
            parameter.Add("@Sali_Transportista", salida.Sali_Transportista);
            parameter.Add("@Sali_Creacion", salida.Sali_Creacion);
            parameter.Add("@Sali_FechaCreacion", DateTime.Now);
            parameter.Add("@JsonDetalles", jsonDetalles);

            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<RequestStatus>(
                ScriptDatabase.Salida_Insertar,
                parameter,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public tbSalidas ObtenerSalidaCompleta(int sali_Id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sali_Id", sali_Id);

            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<tbSalidas>(
                ScriptDatabase.Salida_Seleccionar,
                parameter,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public RequestStatus RecibirSalida(int sali_Id, int UsuarioRecibeId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sali_Id", sali_Id);
            parameter.Add("@UsuarioRecibeId", UsuarioRecibeId);

            parameter.Add("@Sali_FechaModificacion", DateTime.Now);

            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<RequestStatus>(
                ScriptDatabase.Salida_Recibir,
                parameter,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public RequestStatus ActualizarGuiaRemision(int sali_Id, byte[] pdfBytes)
        {
            using var connection = new SqlConnection(BodeTrack_Context.ConnectionString);
            connection.Open();

            using var command = new SqlCommand(ScriptDatabase.Salida_ActualizarGuia, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Sali_Id", sali_Id);

            var paramGuia = new SqlParameter("@GuiaPDF", SqlDbType.VarBinary, -1)
            {
                Value = pdfBytes ?? (object)DBNull.Value
            };
            command.Parameters.Add(paramGuia);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new RequestStatus
                {
                    code_Status = reader.GetInt32(reader.GetOrdinal("Code_Status")),
                    message_Status = reader.GetString(reader.GetOrdinal("Message_Status"))
                };
            }

            return new RequestStatus
            {
                code_Status = 0,
                message_Status = "Error desconocido al actualizar guía."
            };
        }

        public byte[] ObtenerGuiaRemision(int sali_Id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sali_Id", sali_Id);
            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            var salida = db.QueryFirstOrDefault<tbSalidas>(
                "SELECT Sali_GuiaRemision FROM [Inve].[tbSalidas] WHERE Sali_Id = @Sali_Id",
                parameter
            );
            return salida?.Sali_GuiaRemision;
        }
    }
}