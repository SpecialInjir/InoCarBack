using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class ResetPasswordCode
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
    
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public User User { get; set; }

        public ResetPasswordCode(string userId, string code)
        {
            UserId = userId;
            Code = code;
            CreatedDate = DateTime.Now;
            IsActive = true;
        }
    }
}
