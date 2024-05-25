using System.Text;
using Application;
using Domain;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace IoTDeviceManagerService.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly UserService service;
    private readonly UserListProvider UserList;

    public UserController(UserService userService, UserListProvider userList)
    {
        service = userService;
        UserList = userList;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(string name, string email, string password)
    {
        if (UserList.Users.Find(user => user.Email == email) != null)
        {
            return BadRequest("Email already exist");
        }

        UserList.Users.Add(new User(name, email, password));

        return CreatedAtAction(nameof(Create), null);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = UserList.Users.Find(user => user.Email == email);
        
        if (user == null)
        {
            return NotFound("Credentials are incorrect");
        }

        if (user.Password != password)
        {
            return BadRequest("Credentials are incorrect");
        }

        var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Id + ":" + user.Password));

        return Ok(encodedToken);
    }
}
