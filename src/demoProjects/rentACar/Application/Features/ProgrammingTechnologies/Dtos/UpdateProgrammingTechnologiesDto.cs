using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Dtos
{
    public class UpdateProgrammingTechnologiesDto
    {
        public int ProgrammingLanguageId { get;set; }
        public string TechnologyName { get; set; }
        public string TehcnologyDescription { get; set; }
    }
}
