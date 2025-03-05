using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWSRP
{
    public class ParticipantManagment
    {
        public GroupManagment _groupManagment = new GroupManagment();
        public ParticipantManagment(GroupManagment groupManagment)
        {
            _groupManagment = groupManagment;
        }

        public void AddUserToGroup(string username, string groupName)
        {
            var _userGroup = _groupManagment.GetGroupByName(groupName);
            if (_groupManagment.GroupExists(groupName))
            {
                _userGroup.Participant.Add(new Participant { Username = username });
                Console.WriteLine($"User {username} added");
            }
            else
            {
                Console.WriteLine($"Group {groupName} does not exist");
            }
        }
        public void RemoveUserFromGroup(string username, string groupName)
        {
            var _userGroup = _groupManagment.GetGroupByName(groupName);

            if (_userGroup == null)
            {
                Console.WriteLine($"User group {groupName} does not exist.");
                return;
            }

            if (_userGroup.Participant.Any(x => x.Username == username))
            {
                _userGroup.Participant.Remove(new Participant { Username = username });
                Console.WriteLine($"User {username} removed from group {groupName}.");
            }
            else
            {
                Console.WriteLine($"User {username} doesn't exists in group {groupName}.");
            }
        }
    }
}
