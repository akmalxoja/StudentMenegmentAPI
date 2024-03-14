using Permission_Domen.Entityes;
using Permission_Infrastructure;
using VehicleManagement_Infrastructure;

namespace VehicleManagementAPI.Data
{
    public static class SeedDataUser
    {
        public static async Task InitiliazaDataAsync(this IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<AppDbContext>();
            if(!db.Users.Any())
            {
                List<User> Useers = [
                    new User(){
                        Name = "Xushnud",
                        Email = "Xushnud@Gmail.com",
                        Password = "xushnud123",
                        ERole = Permission_Domen.Enums.ERole.Admin,
                        CreatedAt = DateTime.UtcNow,
                    },
                     new User(){
                        Name = "Nurali",
                        Email = "Nurali@Gmail.com",
                        Password = "Nurali123",
                        ERole = Permission_Domen.Enums.ERole.Manengment,
                        CreatedAt = DateTime.UtcNow,
                    },
                     new User(){
                        Name = "Abdumutal",
                        Email = "Abdumutal@Gmail.com",
                        Password = "Abdumutal123",
                        ERole = Permission_Domen.Enums.ERole.User,
                        CreatedAt = DateTime.UtcNow,
                    },
                    ];

                await db.Users.AddRangeAsync(Useers);
                await db.SaveChangesAsync();
            }
        }
    }
}
