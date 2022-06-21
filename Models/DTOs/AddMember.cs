using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2proba2.Models.DTOs
{
    public class AddMember
    {
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberNickname { get; set; }
    }
}