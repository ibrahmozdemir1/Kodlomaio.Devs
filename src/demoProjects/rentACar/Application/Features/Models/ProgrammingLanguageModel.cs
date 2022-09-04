using Application.Features.ProgrammingLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models
{
    public class ProgrammingLanguageModel : BasePageableModel
    {
        public List<GetListProgrammingLanguageDto> Items { get; set; }
    }
}
