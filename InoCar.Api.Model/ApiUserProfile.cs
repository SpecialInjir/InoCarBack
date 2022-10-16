using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiUserProfile
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }

        public string Email { get; set; }

        public DateTime DateBirth { get; set; }

        public string? City { get; set; }
    }
}
