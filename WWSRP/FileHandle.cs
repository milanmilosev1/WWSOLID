﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWSRP
{
    public class FileHandle
    {
        public UserManagement _userManagment = new UserManagement();

        public FileHandle (UserManagement userManagment)
        {
            _userManagment = userManagment;
        }

        // Save user data to a file
        public void SaveDataToFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var participant in _userManagment.GetAllParticipants())
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
