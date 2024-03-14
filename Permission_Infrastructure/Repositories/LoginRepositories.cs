using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Infrastructure.JWT_Token;
using VehicleManagement_Infrastructure;

namespace Permission_Infrastructure.Repositories
{
    public class LoginRepositories : ILogin
    {
        private readonly IConfiguration _configuration;

        private readonly AppDbContext _dbContext;
        public LoginRepositories(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<string> Loogin(LoginDTO user)
        {

            var newUser = await _dbContext.
                Users.FirstOrDefaultAsync(x => x.Password == user.Password && x.Email == user.Email);

            if(newUser == null) 
            {
                return "Not Faund User";
            }

            var jwtToken = new GeneretTokenServies(_configuration);
            var resust = jwtToken.GenerateToken(newUser);
            return await resust;
        }
    }
}
