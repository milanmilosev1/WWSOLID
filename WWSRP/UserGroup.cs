using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWSRP
{
    public class UserGroup
    {
        public string? GroupName { get; set; }
        public List<Participant> Participant { get; set; } = new List<Participant>();
    }
}
