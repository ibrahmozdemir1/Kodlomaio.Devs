using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserApplication : User 
    {
        public ICollection<UserSocialMedia> UserSocialMedias { get; set; }

        public UserApplication() : base() { }

        public UserApplication(int id, String firstName, String lastName, String email, Byte[] passwordSalt, Byte[] passwordHash, Boolean status, AuthenticatorType authenticatorType) : base(id, firstName, lastName, email, passwordSalt, passwordHash, status, authenticatorType)
        {
        }
    }
}
