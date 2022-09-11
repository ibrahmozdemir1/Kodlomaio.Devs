using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Queries.GetListUserSocialMedia;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Models
{
    public class GetListUserSocialMediaModel : BasePageableModel
    {
        public List<GetListUserSocialMediaDto> Items { get; set; }
    }
}
