using Application.Features.ProgrammingTechnologies.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Models
{
    public class GetListProgrammingTechnologiesModel : BasePageableModel
    {
        public IList<GetListProgrammingTechnologiesModel> Items { get; set; }
    }
}
