using Permission_Application.Dto_s;

namespace Permission_Application.Abstractions.Repositories
{
    public interface ILogin
    {
        Task<string> Loogin(LoginDTO loginDTO);
    }
}
