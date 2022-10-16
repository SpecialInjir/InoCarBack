using InoCar.Data;
using InoCar.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.Entity;

namespace RolesIdentityApp.Models
{
    public class UserRole
    {

        public const string User = "User";
        public const string Admin = "Admin";
    }
}