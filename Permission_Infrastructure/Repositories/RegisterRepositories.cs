using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Domen.Entityes;
using VehicleManagement_Infrastructure;

namespace Permission_Infrastructure.Repositories
{
    public class RegisterRepositories : IRegister
    {
        private readonly AppDbContext _appDbContext;
        public RegisterRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Permission_Domen.Entityes.User> Registration(RegisterDTO registerDTO)
        {
            var newuser = new User();
            newuser.Name = registerDTO.Name;
            newuser.Email = registerDTO.Email;
            newuser.Password = registerDTO.Password;
            newuser.ERole = registerDTO.ERole;
            newuser.CreatedAt = DateTime.UtcNow;

            await _appDbContext.AddAsync(newuser);
            await _appDbContext.SaveChangesAsync();
            return newuser;
        }
    }
}
