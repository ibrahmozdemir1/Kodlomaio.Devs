using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Dtos
{
    public class GetListProgrammingTechnologiesDto
    {
        public int Id { get; set; }
        public string TehcnologyName { get; set; }
        public string TehcnologyDescription { get; set; }
        public string LanguageName { get; set; }
    }
}
