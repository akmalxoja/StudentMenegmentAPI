using Permission_Application.Abstractions.Repositories;
using Permission_Infrastructure;
using Permission_Infrastructure.Generic;
using VehicleManagement_Domen.Entityes;

namespace VehicleManagement_Infrastructure.Repositories
{
    public class StudentRepositories : GenericRepositories<Students>, IStudnetRepositories
    {
        public StudentRepositories(AppDbContext app) : base(app)
        {
        }
    }
}
