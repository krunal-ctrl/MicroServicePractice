using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepo
{
    bool SaveChanges();
    IEnumerable<Platform> GetAll();
    Platform? Get(int id);
    void Create(Platform platform);
}