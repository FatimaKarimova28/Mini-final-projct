using System;
using Core.Entities;
using Core.Helpers;
using Data.Contexts;

namespace Data.Repositoriesofmethods.Concrete
{
    public class AdminRepository : IAdminRepository
    {
        public Admin GetByUsernameAndPassword(string username, string password)
        {
            return DbContext.Admins.FirstOrDefault(a => a.Username.ToLower() == username.ToLower() && PasswordHasher.Decrypt(a.Password) == password);
        }
    }
}

