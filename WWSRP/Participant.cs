using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWSRP
{
    public class Participant
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Participant(string? username, string? password)
        {
            Username = username;
            Password = password;
        }
    }
}
