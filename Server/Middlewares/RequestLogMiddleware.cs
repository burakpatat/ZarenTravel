
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


public class RequestLogMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        System.Collections.Generic.IEnumerable<System.Security.Claims.Claim> claims = context.User.Claims;
        long? UserId = null;
        string _user = claims != null ? claims.FirstOrDefault(c => c.Type == "UserId")?.Value : string.Empty;
        if (!string.IsNullOrWhiteSpace(_user))
        {
            UserId = Convert.ToInt64(_user);
        }

        //First, get the incoming request
        context.Items["UniqueId"] = Guid.NewGuid().ToString("N");
        string request = await FormatRequest(context.Request);
        DateTime requestDate = DateTime.UtcNow;
        //var yourClass = JsonConvert.DeserializeObject<YourClass>(json);

        //Copy a pointer to the original response body stream
        Stream originalBodyStream = context.Response.Body;
        string response = "";
        DateTime responseDate = DateTime.UtcNow;
        //Create a new memory stream...

        using (MemoryStream responseBody = new MemoryStream())
        {
            //...and use that for the temporary response body
            context.Response.Body = responseBody;

            //Continue down the Middleware pipeline, eventually returning to this class
            await _next(context);

            //Format the response from the server
            response = await FormatResponse(context.Response);
            responseDate = DateTime.UtcNow;
            //TODO: Save log to chosen datastore

            //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
            await responseBody.CopyToAsync(originalBodyStream);
        }
        if (context.Request.Method != "GET")
        {
            //LoggerData business = new LoggerData(MyConfiguration.Configuration.GetSection("ConnectionStringLog").Value);
            //string url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
            //int duration = Convert.ToInt32((responseDate - requestDate).TotalMilliseconds);
            //business.Insert(new LogModel
            //{
            //    ResponseCode = context.Response.StatusCode,
            //    Method = context.Request.Method,
            //    Id = Guid.NewGuid(),
            //    UserId = UserId,
            //    UniqId = Guid.Parse(context.Items["UniqueId"].ToString()),
            //    Request = request,
            //    Response = response,
            //    Url = url,
            //    RequestDate = requestDate,
            //    ResponseDate = responseDate,
            //    Duration = duration
            //});
        }
    }

    private async Task<string> FormatRequest(HttpRequest request)
    {
        request.EnableBuffering();
        string body = await new StreamReader(request.Body).ReadToEndAsync();
        request.Body.Seek(0, SeekOrigin.Begin);
        return body;
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        //We need to read the response stream from the beginning...
        response.Body.Seek(0, SeekOrigin.Begin);

        //...and copy it into a string
        string text = await new StreamReader(response.Body).ReadToEndAsync();

        //We need to reset the reader for the response so that the client can read it.
        response.Body.Seek(0, SeekOrigin.Begin);

        //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
        return text;
    }
}
