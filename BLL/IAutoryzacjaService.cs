using BLL.Models;

namespace BLL
{
    public interface IAutoryzacjaService
    {
        public LoggedUserDTO Login(LoginFormDTO loginFormDTO);
    }
}
