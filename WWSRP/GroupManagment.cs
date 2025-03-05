using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWSRP
{
    public class GroupManagment
    {
        private readonly List<UserGroup> _userGroups = new List<UserGroup>();

        public bool GroupExists(string groupName)
        {
            if (_userGroups.Any(x => x.GroupName == groupName))
                return true;
            else
                return false;
        }

        public UserGroup GetGroupByName(string groupName)
        {
            return _userGroups.FirstOrDefault(x => x.GroupName == groupName);
        }

        public void CreateGroup(string name)
        {
            if (!GroupExists(name))
            {
                _userGroups.Add(new UserGroup { GroupName = name });
                Console.WriteLine($"User group {name} added.");
            }
            else
            {
                Console.WriteLine($"User group {name} already exists.");
            }
        }
    }
}
