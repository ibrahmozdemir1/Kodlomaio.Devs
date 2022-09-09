using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingTehcnologies : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string TehcnologyName { get; set; }
        public string TehcnologyDescription { get; set; }
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingTehcnologies()
        {
        }

        public ProgrammingTehcnologies(int id, int programmingLanguageid, string tehcnologyName, string tehcnologyDescription) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageid;
            TehcnologyName = tehcnologyName;
            TehcnologyDescription = tehcnologyDescription;
        }
    }
}
