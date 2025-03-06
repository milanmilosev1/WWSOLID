using WWSRP;

Participant p1 = new Participant("milan", "password");
Participant p2 = new Participant("marko", "password");

GroupManagment group1 = new GroupManagment();
group1.CreateGroup("Group1");

UserManagement user1 = new UserManagement();
user1.AddUser(p1);
user1.AddUser(p2);

Repository repo1 = new Repository(user1, group1);

group1.AddUserToGroup(p1, "Group1");
FileHandle fileHandle = new FileHandle(repo1);

fileHandle.SaveDataToFile("data.txt");

