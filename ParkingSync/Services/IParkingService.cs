using System.Threading.Tasks;

namespace ParkingSync.Services;

public interface IParkingService<T>
{
Task<T> GetDataAsync();
}
