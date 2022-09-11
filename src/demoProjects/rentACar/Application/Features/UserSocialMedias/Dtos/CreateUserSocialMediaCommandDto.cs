using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Dtos
{
    public class CreateUserSocialMediaCommandDto
    {
        public int Id { get; set; }
        public string GitHubLink { get; set; }
    }
}
