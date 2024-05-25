using System.Text;
using Domain;

namespace Web.Middleware;

public class BasicAuth
{

    private readonly RequestDelegate Next;
    private readonly UserListProvider UserList;

    public BasicAuth(RequestDelegate next, UserListProvider userList)
    {
        Next = next;
        UserList = userList;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.ToString().Contains("users"))
        {
            await Next(context);
            return;
        }
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {

            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        var header = context.Request.Headers["Authorization"].ToString();

        var encodedCreds = header;

        var cred = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));

        string[] uidpwd = cred.Split(":");
        var uid = uidpwd[0];
        var password = uidpwd[1];

        var user = UserList.Users.Find(user => user.Id.ToString() == uid);

        if (user == null)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("User not found");
            return;
        }

        if (user.Password != password)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await Next(context);
    }
}