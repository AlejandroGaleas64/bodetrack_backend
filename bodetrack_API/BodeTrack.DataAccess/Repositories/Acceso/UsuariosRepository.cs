using BodeTrack.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BodeTrack.DataAccess.Repositories.Acceso
{
    public class UsuariosRepository : IRepository<tbUsuarios>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbUsuarios> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios Login(tbUsuarios item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_NombreUsuario", item.Usua_NombreUsuario);
            parameter.Add("@Usua_Clave", item.Usua_Clave);

            using var db = new SqlConnection(BodeTrack_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<tbUsuarios>(
                ScriptDatabase.Usuario_IniciarSesion,
                parameter,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}