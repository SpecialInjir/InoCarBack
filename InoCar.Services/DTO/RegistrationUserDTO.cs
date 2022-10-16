using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.DTO
{
    public  class RegistrationUserDTO
    {

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string Code { get; set; }
       

    }
}
