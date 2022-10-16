
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class User :IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateBirth { get; set; }
        public string? City { get; set; }
        public string? RegistrationCode { get; set; }
        public bool IsDeleted { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public List<ResetPasswordCode> ResetPasswordCodes { get; set; }
        public List<CarCertificate> CarCertificates { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; }

       


    }
}
