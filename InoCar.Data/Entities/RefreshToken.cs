using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Entities
{
    public class RefreshToken 
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }

        public RefreshToken(string userId, string token)
        {
            UserId = userId;
            Token = token;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive= true;
        }
    }

}
