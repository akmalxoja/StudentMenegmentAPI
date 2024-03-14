using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement_Domen.Entityes;

namespace VehicleManagement_Application.Services.EmailSender
{
    public interface IForgetEmail
    {
        public Task SendEmailAsync(string model);
    }
}
