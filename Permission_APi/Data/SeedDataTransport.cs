using Permission_Infrastructure;
using VehicleManagement_Domen.Entityes;
using VehicleManagement_Infrastructure;

namespace Permission_APi.Data
{
    public static class SeedDataStudent
    {
        public static async Task InitiliazeDataAsync(this IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<AppDbContext>();
            if (!db.Students.Any())
            {
                List<Students> students = [
                     new Students
                     {
                         Name = "Akmal",
                         Lastname = "Sharifxojayev",
                         age = 20,
                         ImageUrl = "",
                         CreatedAt = DateTime.UtcNow

                        
                     },
                     new Students
                     {
                         Name = "Otabek",
                         Lastname = "Meliqoziyev",
                         age = 20,
                         ImageUrl = "",
                         CreatedAt = DateTime.UtcNow

                     }
                    ];
                db.Students.AddRange(students);
                await db.SaveChangesAsync();
            }
        }

    }
}
