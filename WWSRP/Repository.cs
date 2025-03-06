using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWSRP
{
    public class Repository
    {
        public UserManagement _userManagement { get; set; } = new UserManagement();
        public GroupManagment _groupManagment { get; set; } = new GroupManagment();

        
    }
}
