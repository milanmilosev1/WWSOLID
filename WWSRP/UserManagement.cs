namespace WWSRP
{
	public class UserGroup
	{
		public string Name { get; set; }
		public List<string> Participants { get; set; } = new List<string>();
	}

	public class UserManagement
	{
		private readonly Dictionary<string, string> _userData;
		private readonly List<UserGroup> _userGroups;

		public UserManagement()
		{
			_userData = [];
			_userGroups = new();
		}

		// Create new group
		public void CreateGroup(string name)
		{
			if (!_userGroups.Any(x => x.Name == name))
			{
				_userGroups.Add(new UserGroup { Name = name });
				Console.WriteLine($"User group {name} added.");
			}
			else
			{
				Console.WriteLine($"User group {name} already exists.");
			}
		}

		// Add user to group
		public void AddUserToGroup(string username, string groupName)
		{
			var userGroup = _userGroups.FirstOrDefault(x => x.Name == groupName);

			if (userGroup == null)
			{
				Console.WriteLine($"User group {groupName} does not exist.");

				return;
			}

			if (!userGroup.Participants.Any(x => x == username))
			{
				userGroup.Participants.Add(username);

				Console.WriteLine($"User {username} added to group {groupName}.");
			}
			else
			{
				Console.WriteLine($"User {username} already exists in group {groupName}.");
			}
		}

		// Remove User from group
		public void RemoveUserFromGroup(string username, string groupName)
		{
			var userGroup = _userGroups.FirstOrDefault(x => x.Name == groupName);

			if (userGroup == null)
			{
				Console.WriteLine($"User group {groupName} does not exist.");

				return;
			}

			if (userGroup.Participants.Any(x => x == username))
			{
				userGroup.Participants.Remove(username);
				Console.WriteLine($"User {username} removed from group {groupName}.");
			}
			else
			{
				Console.WriteLine($"User {username} doesn't exists in group {groupName}.");
			}
		}

		// Add a new user
		public void AddUser(string username, string password)
		{
			if (!_userData.ContainsKey(username))
			{
				_userData[username] = password;
				Console.WriteLine($"User {username} added.");
			}
			else
			{
				Console.WriteLine($"User {username} already exists.");
			}
		}

		// Update an existing user's password
		public void UpdateUserPassword(string username, string newPassword)
		{
			if (_userData.ContainsKey(username))
			{
				_userData[username] = newPassword;
				Console.WriteLine($"Password for {username} updated.");
			}
			else
			{
				Console.WriteLine($"User {username} not found.");
			}
		}

		// Delete an existing user
		public void DeleteUser(string username)
		{
			if (_userData.ContainsKey(username))
			{
				_userData.Remove(username);
				Console.WriteLine($"User {username} deleted.");
			}
			else
			{
				Console.WriteLine($"User {username} not found.");
			}
		}

		// Authenticate a user
		public void AuthenticateUser(string username, string password)
		{
			if (_userData.ContainsKey(username) && _userData[username] == password)
			{
				Console.WriteLine("User authenticated.");
			}
			else
			{
				Console.WriteLine("Authentication failed.");
			}
		}

		// Save user data to a file
		public void SaveDataToFile(string fileName)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(fileName))
				{
					foreach (var user in _userData)
					{
						writer.WriteLine($"{user.Key},{user.Value}");
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
						_userData[parts[0]] = parts[1];
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
					foreach (var user in _userData)
					{
						writer.WriteLine($"{user.Key},{user.Value}");
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

		// Display all users
		public void DisplayAllUsers()
		{
			if (_userData.Count > 0)
			{
				Console.WriteLine("All users:");
				foreach (var user in _userData)
				{
					Console.WriteLine($"Username: {user.Key}, Password: {user.Value}");
				}
			}
			else
			{
				Console.WriteLine("No users available.");
			}
		}
	}
}
