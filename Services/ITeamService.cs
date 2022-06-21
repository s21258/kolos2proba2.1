using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2proba2.Services
{
    public interface ITeamService
    {
        public Task AddMember(Member member);
    }
}