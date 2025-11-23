namespace BodeTrack.API.Helpers
{
    public interface IApiKeyValidator
    {
        public bool IsValid(string apikey);
    }
}