using Microsoft.AspNetCore.Http;

namespace TodoListApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Applicatoin-Error", message);
            response.Headers.Add("Access-Control-Expose-Header", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}