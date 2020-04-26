using System.Threading.Tasks;

namespace EasyCatch.API.Repositories
{
    public interface IUserRepository
    {
         Task<bool> UserExists(string username);

    }
}