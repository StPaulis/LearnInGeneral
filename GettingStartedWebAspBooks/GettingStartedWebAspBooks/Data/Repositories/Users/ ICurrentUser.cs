using System.Threading.Tasks;
using GettingStartedWebAspBooks.Models;
using GettingStartedWebAspBooks.ViewModels.Users;

namespace GettingStartedWebAspBooks.Data.Repositories.Users
{
    public interface ICurrentUser
    {
        Task<UsersViewModel> GetUserAsync();
        Task<ApplicationUser> GetAppUserAsync();
        string UserId { get; }
    }
}