using Application.Features.Users.Rules;
using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Rules
{
    public class UserSocialMediaBusinessRules
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public async Task UserIdCanNotBeDuplicatedInSocialMedia(int userId)
        {
            _userBusinessRules.UserIdCanNotBeDuplicated(userId);
        }

      
    }
}
