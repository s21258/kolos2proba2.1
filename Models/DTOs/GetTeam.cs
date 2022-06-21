using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2proba2.Models.DTOs
{
    public class GetTeam
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public Organization Organization { get; set; }
        public List<MembersGet> Members { get; set; }
    }
    public class MembersGet
    {
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberNickname { get; set; }  
    }
}