using System.Threading.Tasks;

namespace EveMarket.Services
{
    public interface IAuthenticationService
    {
        Task LogIn();
        Task LogIn(string code);
    }
}