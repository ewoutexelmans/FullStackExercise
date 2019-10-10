using System.Threading.Tasks;
using FullStackExercise.Data.Model;

namespace FullStackExercise.Business.Infrastructure
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}
