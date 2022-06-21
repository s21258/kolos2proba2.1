using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2proba2.Models
{
    public class Organisation
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDomain { get; set; }

        public virtual IEnumerable<Team> Team { get; set; }
        public virtual IEnumerable<Member> Member { get; set; }
    }
}