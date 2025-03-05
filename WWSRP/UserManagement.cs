namespace WWSRP
{ 
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
}
