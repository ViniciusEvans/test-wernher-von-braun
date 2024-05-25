using Application;
using Domain.Model;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;


namespace IoTDeviceManagerService.Controllers;

[ApiController]
[Route("devices")]
public class DeviceController : ControllerBase
{
	private readonly DeviceService deviceService;

	private readonly IotDeviceConnectService iotDeviceConnectService = new IotDeviceConnectService();

	[ActivatorUtilitiesConstructor]
	public DeviceController(
		DeviceService service
		)
	{
		deviceService = service;
	}

	[HttpGet]
	[Route("")]
	public async Task<IActionResult> GetDevices()
	{
		List<Device> devices = await deviceService.GetDevices();
		return Ok(devices);
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> CreateDevice(Device device)
	{
		await deviceService.CreateDevice(device);
		return CreatedAtAction(nameof(CreateDevice), device);

	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetDevice(Guid id)
	{
		var device = await deviceService.GetDeviceById(id);
		if (device == null)
		{
			return NotFound();
		}
		return Ok(device);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateDevice(Guid id, Device device)
	{
		await deviceService.UpdateDevice(id, device);

		return Ok(null);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteDevice(Guid id)
	{
		await deviceService.DeleteDevice(id);

		return Ok(null);
	}

	[HttpPost("{id}/send-command")]
	public async Task<IActionResult> SendDevice(Guid id, Command command)
	{
		var device = await deviceService.GetDeviceById(id);

		if (device == null)
		{
			return NotFound();
		}

		iotDeviceConnectService.ConnectToDevice(device.Url);

		iotDeviceConnectService.SendCommand(command.command);

		var dataReceived = iotDeviceConnectService.ReceiveData();

		iotDeviceConnectService.CloseConnection();

		Console.WriteLine("dataReceived");
		Console.WriteLine(dataReceived);

		return Ok(dataReceived);
	}
}
