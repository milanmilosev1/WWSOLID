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

        public UserGroup? GetGroupByName(string groupName)
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
        public void AddUserToGroup(Participant participantObj, string groupName)
        {
            var group = _userGroups.FirstOrDefault(x => x.GroupName == groupName);
            if (group != null)
            {
                group.Participant.Add(participantObj);
                Console.WriteLine($"User {participantObj.Username} added");
            }
            else
            {
                Console.WriteLine($"Group {groupName} does not exist");
            }
        }
        public void RemoveUserFromGroup(Participant participantObj, string groupName)
        {
            var group = _userGroups.FirstOrDefault(x => x.GroupName == groupName);
            if (group == null)
            {
                Console.WriteLine($"User group {groupName} does not exist.");
                return;
            }

            if (group.Participant.Any(x => x.Username == participantObj.Username))
            {
                group.Participant.Remove(participantObj);
                Console.WriteLine($"User {participantObj.Username} removed from group {groupName}.");
            }
            else
            {
                Console.WriteLine($"User {participantObj.Username} doesn't exists in group {groupName}.");
            }
        }
    }
}
