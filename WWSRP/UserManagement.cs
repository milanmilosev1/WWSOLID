namespace WWSRP
{ 
	public class UserManagement
	{
		private readonly List<Participant> participants = new List<Participant>();

		// Add a new user
		public bool AddUser(Participant participantObj)
		{
			foreach (var participant in participants)
			{
				if (participant.Username == participantObj.Username)
				{
					Console.WriteLine($"User with username: {participantObj.Username} already exists");
					return false;
				}
			}
			participants.Add(new Participant(participantObj.Username, participantObj.Password));
			Console.WriteLine("User created succesfully!");
			return true;
		}

		// Update an existing user's password
		public bool UpdateUserPassword(Participant participantObj)
		{
			foreach (var participant in participants)
			{
				if (participant.Username != participantObj.Username)
				{
					Console.WriteLine("User not found");
					return false;
				}
				else
				{
					participant.Password = participantObj.Password;
					Console.WriteLine("Password updated succesfully!");
					return true;
				}
			}
			return false;
		}

		// Delete an existing user
		public void DeleteUser(Participant participantObj)
		{
			var user = participants.SingleOrDefault(x => x.Username == participantObj.Username);
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
		public bool AuthenticateUser(Participant participantObj)
		{
			foreach (var participant in participants)
			{
				if (participant.Username == participantObj.Username && participant.Password == participantObj.Password)
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
