using System.Threading.Tasks;

namespace Pwa.Infrastructure.EfCore.SeedData
{
    public interface IDataInitializer
    {
        Task Initialize();
    }
}
