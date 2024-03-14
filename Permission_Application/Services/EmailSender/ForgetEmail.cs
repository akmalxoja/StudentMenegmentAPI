using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement_Domen.Entityes;
using VehicleManagement_Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace VehicleManagement_Application.Services.EmailSender
{
    public class ForgetEmail : IForgetEmail
    {
        private readonly IConfiguration _config;
        private readonly IDbContext _dbContext;


        public ForgetEmail(IConfiguration config, IDbContext dbContext)

        {
            _config = config;
            _dbContext = dbContext;
        }
        public async Task SendEmailAsync(string model)
        {

            Random random = new Random();
            int sender = random.Next(100000, 999999);

            var emailSettings = _config.GetSection("EmailSettings");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = sender.ToString(),
                Body = "Sizga yahngi cod tqadim etildi buni unitmalik tavsiya etiladi",
                IsBodyHtml = true,

            };

            var result = await _dbContext.Users.FirstOrDefaultAsync(x=> x.Email == model);

            result.Password = sender.ToString();
            mailMessage.To.Add(result.Email);
            await _dbContext.SaveChanges();

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
