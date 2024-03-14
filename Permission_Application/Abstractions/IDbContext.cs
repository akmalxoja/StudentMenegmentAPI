using Microsoft.EntityFrameworkCore;
using Permission_Domen.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagement_Application.Abstractions
{
    public interface IDbContext
    {
        public DbSet<User> Users { get; set; }
        public ValueTask<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
