using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingLanguage: Entity
    {
        public string LanguageName { get; set; }
        public virtual ICollection<ProgrammingTehcnologies> ProgrammingTehcnologiess { get; set; }
        public ProgrammingLanguage()
        {
        }

        public ProgrammingLanguage(int id, string name) : this()
        {
            Id = id;
            LanguageName = name;
        }
    }
}
