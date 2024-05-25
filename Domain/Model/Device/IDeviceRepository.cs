namespace Domain.Model;

public interface IDeviceRepository
{
    Task GetAll();
    Task Store(Device device);
    Task GetDeviceById(Guid id);
    Task Remove(Guid id);
}