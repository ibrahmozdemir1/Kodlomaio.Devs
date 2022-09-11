using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSocialMedia : Entity
    {
        public string GitHubLink { get; set; }
        public int UserId { get; set; }
        public UserApplication? User { get; set; }

        public UserSocialMedia()
        {
        }

        public UserSocialMedia(string gitHubLink, int userId, UserApplication? user) : this()
        {
            GitHubLink = gitHubLink;
            UserId = userId;
            User = user;
        }
    }
}
