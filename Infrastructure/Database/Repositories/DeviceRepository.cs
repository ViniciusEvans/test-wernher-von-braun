using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class DeviceRepository : IDeviceRepository
{

    /*
        Os códigos comentados abaixo é que seria em caso real,
        mas está comentado pois precisaria de conexão com um
        banco de dados real e preenchido com os dados. Para 
        rodar o projeto sem precisar realizar muito passos usaremos dados em memória.
    */
    private readonly DbContext _context;

    public DeviceRepository(DbContext context)
    {
        _context = context;

    }


    public async Task GetAll()
    {
        // 
        // Device? result = await _context.Set<Device>().FindAsync();

        // return result;

    }

    public async Task Store(Device device)
    {

        // var result = await _context.Set<Device>().AddAsync(Device);

    }

    public async Task GetDeviceById(Guid id)
    {
        // var device = await _context.Set<Device>().FindAsync(id);

        // return device;

    }

    public async Task Remove(Guid id)
    {
        // var result = await _context.Set<Device>().FindAsync(id);

        // if (result == null)
        // {
        //     throw new ArgumentException("Device not found");
        // }

        // _context.Remove(result);

    }
}