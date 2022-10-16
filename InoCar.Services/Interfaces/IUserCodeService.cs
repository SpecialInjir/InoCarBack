using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services
{
    public interface IUserCodeService
    {
        bool SendEmail(string email, string body, string subject);
        Task<bool> CompareCodeAsync(string email, string code);
        string CreateCode(int size);
        bool SendResetPasswordURL(string email, string code);
    }
}
