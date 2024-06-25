using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo(AppDbContext dbContext): IPlatformRepo
{
    public bool SaveChanges()
    {
        return dbContext.SaveChanges() >= 0;
    }

    public IEnumerable<Platform> GetAll()
    {
        return dbContext.Platforms.AsEnumerable();
    }

    public Platform? Get(int id)
    {
        return dbContext.Platforms.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Platform platform)
    {
        if (platform is null)
        {
            throw new ArgumentNullException();
        }
        dbContext.Platforms.Add(platform);
        SaveChanges();
    }
}