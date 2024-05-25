using Domain.Model;

namespace Domain.Services;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IDeviceRepository Devices { get; }
    Task<int> Complete();
}