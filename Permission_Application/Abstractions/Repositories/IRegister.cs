using Permission_Application.Dto_s;
using Permission_Domen.Entityes;

namespace Permission_Application.Abstractions.Repositories
{
    public interface IRegister
    {
        Task<User> Registration(RegisterDTO registerDTO);
    }
}
