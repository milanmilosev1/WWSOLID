using WWSRP;

UserManagement userManagement = new UserManagement();
FileHandle fileHandle = new FileHandle(userManagement);

userManagement.AddUser("milan", "milan123");

userManagement.AuthenticateUser("milan", "milan123");

fileHandle.SaveDataToFile("data.txt");

