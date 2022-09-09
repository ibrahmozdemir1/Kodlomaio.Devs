using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailCanNotBeDuplicated(string email)
        {
            IPaginate<User> users = await _userRepository.GetListAsync(u => u.Email == email);
            if(users.Items.Any()) 
                throw new BusinessException("Developer email already exists");
        }

        public void UserShouldExistWhenRequested(User? user)
        {
            if (user is null)
                throw new BusinessException("Requested user does not exist");
        }

        public void UserCredentialsShouldMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result)
                throw new BusinessException("User credentials do not match");
        }
    }
}
