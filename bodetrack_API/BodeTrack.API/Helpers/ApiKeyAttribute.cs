using Microsoft.AspNetCore.Mvc;

namespace BodeTrack.API.Helpers
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
