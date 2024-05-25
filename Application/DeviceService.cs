using Domain.Services;
using Domain.Model;
using Domain;

namespace Application;

public class DeviceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DevicesListProvider DeviceListProvider;
    private readonly List<Device> Devices;

    public DeviceService(IUnitOfWork unitOfWork, DevicesListProvider devices)
    {
        _unitOfWork = unitOfWork;
        DeviceListProvider = devices;
        Devices = DeviceListProvider.Devices;
    }

    public async Task<List<Device>> GetDevices()
    {
        // List<Device> result = await _unitOfWork.Devices.GetAll();

        return Devices;
    }

    public async Task<Device> CreateDevice(Device device)
    {
        // await _unitOfWork.Devices.Store(device);
        Devices.Add(device);
        return device;
    }

    public async Task<Device?> GetDeviceById(Guid id)
    {
        // Device? device = await _unitOfWork.Devices.GetDeviceById(id);

        return Devices.Find(x => x.Id == id);
    }

    public async Task UpdateDevice(Guid id, Device device)
    {
        // var response = await _unitOfWork.Devices.GetDeviceById(id);

        var result = Devices.Find(x => x.Id == id);

        if (result == null)
        {
            throw new ArgumentException("Dispositivo não encontrado!");
        }

        // await _unitOfWork.Devices.Store(device);

        result.Description = device.Description;
        result.Commands = device.Commands;
        result.Manufacturer = device.Manufacturer;
        result.Url = device.Url;

        Console.WriteLine(Devices.Find(x => x.Id == id).Url);
    }

    public async Task DeleteDevice(Guid id)
    {
        // await _unitOfWork.Devices.Remove(id);
        Devices.Remove(Devices.First(x => x.Id == id));

    }
}