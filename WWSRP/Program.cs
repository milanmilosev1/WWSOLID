using WWSRP;

UserManagement userManager = new UserManagement();

// Add some users
userManager.AddUser("Alice", "password123");
userManager.AddUser("Bob", "password456");

// Display all users
userManager.DisplayAllUsers();

// Authenticate a user
userManager.AuthenticateUser("Alice", "password123");

// Update a user's password
userManager.UpdateUserPassword("Alice", "newpassword123");

// Delete a user
userManager.DeleteUser("Bob");

// Save user data to file
userManager.SaveDataToFile("users.txt");

// Load user data from file
userManager.LoadDataFromFile("users.txt");

// Backup data
userManager.BackupData("backup_users.txt");

// Delete user data file
userManager.DeleteDataFile("users.txt");

// Display all users again
userManager.DisplayAllUsers();