namespace WWSRP
{
	public class Participant
	{
		//public string? Name { get; set; }
		public string? Username { get; set; }
		public string? Password { get; set; }
	}

	public class UserGroup
	{
		public string? GroupName { get; set; }
		public List<Participant> Participant { get; set; } = new List<Participant>();
	}

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

	public class ParticipantManagment
	{
		public GroupManagment _groupManagment = new GroupManagment();

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

	public class UserManagement
	{
		private readonly List<Participant> participants = new List<Participant>();

		// Add a new user
		public bool AddUser(string username, string password)
		{
			foreach (var participant in participants)
			{
				if (participant.Username == username)
				{
					Console.WriteLine($"User with username: {username} already exists");
					return false;
				}
			}
			participants.Add(new Participant { Username = username, Password = password });
			Console.WriteLine("User created succesfully!");
			return true;
		}

		// Update an existing user's password
		public bool UpdateUserPassword(string username, string newPassword)
		{
			foreach (var participant in participants)
			{
				if (participant.Username != username)
				{
					Console.WriteLine("User not found");
					return false;
				}
				else
				{
					participant.Password = newPassword;
					Console.WriteLine("Password updated succesfully!");
					return true;
				}
			}
			return false;
		}

		// Delete an existing user
		public void DeleteUser(string username)
		{
			var user = participants.SingleOrDefault(x => x.Username == username);
			if (user != null)
			{
				participants.Remove(user);
				Console.WriteLine("User deleted");
			}
			else
			{
				Console.WriteLine("User not found");
			}
		}

		// Authenticate a user
		public bool AuthenticateUser(string username, string password)
		{
			foreach (var participant in participants)
			{
				if (participant.Username == username && participant.Password == password)
				{
					Console.WriteLine("User authenticated");
					return true;
				}
			}
			Console.WriteLine("Not authenticated");
			return false;
		}

		// Display all users
		public void DisplayAllUsers()
		{
			if (participants.Count != 0)
			{
				Console.WriteLine("All users:");
				foreach (var participant in participants)
				{
					Console.WriteLine($"Username: {participant.Username}, Password: {participant.Password}");
				}
			}
			else
			{
				Console.WriteLine("No users available.");
			}
		}
		public List<Participant> GetAllParticipants()
		{
			return participants;
		}
	}

	public class FileHandle
	{
		public UserManagement _userManagment = new UserManagement();

		// Save user data to a file
        public void SaveDataToFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
					foreach(var participant in _userManagment.GetAllParticipants())
					{
						writer.Write($"{participant.Username},{participant.Password}");
					}
				}
                Console.WriteLine($"User data saved to {fileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to file: {ex.Message}");
            }
        }

        // Load user data from a file
        public void LoadDataFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
						_userManagment.AddUser(parts[0], parts[1]);
                    }
                }
                Console.WriteLine($"User data loaded from {fileName}.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {fileName} not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from file: {ex.Message}");
            }
        }

        // Backup user data to a backup file
        public void BackupData(string backupFileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(backupFileName))
                {
                    foreach (var user in _userManagment.GetAllParticipants())
                    {
                        writer.WriteLine($"{user.Username},{user.Password}");
                    }
                }
                Console.WriteLine($"User data saved to {backupFileName}.");

                Console.WriteLine($"User data backed up to {backupFileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error backing up data: {ex.Message}");
            }
        }

        // Delete user data file
        public void DeleteDataFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    Console.WriteLine($"File {fileName} deleted.");
                }
                else
                {
                    Console.WriteLine($"File {fileName} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
    }
}
