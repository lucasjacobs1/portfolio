using LogicLayer.Models;

namespace LogicLayer
{
    public interface ILoginService
    {
        bool ValidateLogin(Login login);
    }
}