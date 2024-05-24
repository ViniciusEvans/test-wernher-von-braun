using Application;
using Microsoft.AspNetCore.Mvc;

namespace IoTDeviceManagerService.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly UserService service;

    public UserController(UserService userService)
    {
        service = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(string name, string email, string password)
    {
        await service.Create(name, email,password);

        return CreatedAtAction(nameof(Create), null);
    }
}
