using AutoMapper;
using InoCar.Data.Entities;
using InoCar.Data.Enums;
using InoCar.Repositories;
using InoCar.Services.DTO;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using System.Net;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace InoCar.Services.Impl
{
    public class UserCodeServiceImpl : IUserCodeService
    {

        #region constructors
        public UserCodeServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion constructors

        #region public methods

        public string CreateCode(int size)
        {

            Random res = new();

            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
           

            String randomstring = "";

            for (int i = 0; i < size; i++)
            {
                int x = res.Next(str.Length);

                randomstring += str[x];
            }

            string code = randomstring.ToUpper();

            return code;


        }

      
        public async Task<bool> CompareCodeAsync(string email, string code)
        {

            User? user =  await _userRepository.GetUserByEmailAsync(email);

            if (user!=null && user.RegistrationCode == code)
            {
                user.EmailConfirmed = true;
                await _userRepository.UpdateUserAsync(user); 
             
                return true;
            }
            else
            {
                return false;
            }
         
        }

         
         public bool SendEmail(string email, string body, string subject)
         {

            var email1 = new MimeMessage();
            email1.From.Add(MailboxAddress.Parse("John-old@mail.ru"));
            email1.To.Add(MailboxAddress.Parse(email));
            email1.Subject = subject; 
            email1.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.mail.ru", 25, SecureSocketOptions.StartTls);
            smtp.Authenticate("John-old@mail.ru", "X7rqQQa88zq5gnyjgxLZ");
            smtp.Send(email1);
            smtp.Disconnect(true);

            return true;

          }

        public bool SendResetPasswordURL(string email, string code)
        {
            string url = $"/password/reset?token={code}&email={email}"; // сомнительный момент
            var email1 = new MimeMessage();
            email1.From.Add(MailboxAddress.Parse("John-old@mail.ru"));
            email1.To.Add(MailboxAddress.Parse(email));
            email1.Subject = "Сброс пароля:";
            email1.Body = new TextPart(TextFormat.Html) { Text = $"<a href = \"{url}\">Reset password link </a>"}; 

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.mail.ru", 25, SecureSocketOptions.StartTls);
            smtp.Authenticate("John-old@mail.ru", "X7rqQQa88zq5gnyjgxLZ");
            smtp.Send(email1);
            smtp.Disconnect(true);

            return true;

        }

        #endregion public methods

        #region private fields


        private readonly IUserRepository _userRepository;

        #endregion private fields
    }
}
