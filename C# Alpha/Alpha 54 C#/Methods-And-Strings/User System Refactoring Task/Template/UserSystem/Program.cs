namespace UserSystem
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static string[,] userTable = new string[4, 2];

        // Used in bool IsIndexLocated() to detirmine the if statement used in FindIndexInUserTable()
        private static int index = 0;

        // Used when checking for index in userTable
        private static List<string> parameters = new List<string>();

        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            // Main loop
            while (command != "end")
            {
                string[] commandArgs = command.Split(" ");

                CommandInterpreter(commandArgs);

                Console.ResetColor();
                // Read next command
                command = Console.ReadLine();
            }
        }

        private static void CommandInterpreter(string[] commandArgs)
        {
            switch (commandArgs[0])
            {
                case "register":
                    {
                        Register(commandArgs);
                        break;
                    }
                case "delete":
                    {
                        Delete(commandArgs);
                        break;
                    }
            }
        }

        private static void Register(string[] commandArgs)
        {
            if (!ValidateArguements(commandArgs))
            {
                return;
            }

            string username = commandArgs[1];
            string password = commandArgs[2];

            // Check if username exists
            parameters.Add(username);

            if (DoesUserExist("Username already exists."))
            {
                return;
            }

            // Find free slot
            parameters.Add("null");

            int freeSlotIndex = ValidateIndex("The system supports a maximum number of 4 users.");

            if (freeSlotIndex == -1)
            {
                return;
            }

            // Save user
            SaveUser(freeSlotIndex, username, password);
        }

        private static void Delete(string[] commandArgs)
        {
            if (!ValidateArguements(commandArgs))
            {
                return;
            }

            string username = commandArgs[1];
            string password = commandArgs[2];

            // Find account to delete
            parameters.Add(username);
            parameters.Add(password);

            int accountIndex = ValidateIndex("Invalid account/password.");

            if (accountIndex == -1)
            {
                return;
            }

            RemoveUser(accountIndex, username, password);
        }

        private static void SaveUser(int freeSlotIndex, string username, string password)
        {
            userTable[freeSlotIndex, 0] = username;
            userTable[freeSlotIndex, 1] = password;

            PrintMessage("Registered user.", ConsoleColor.DarkGreen);
        }

        private static void RemoveUser(int accountIndex, string username, string password)
        {
            userTable[accountIndex, 0] = null;
            userTable[accountIndex, 1] = null;

            PrintMessage("Deleted account.", ConsoleColor.DarkGreen);
        }

        private static bool DoesUserExist(string message)
        {
            int indexExists = FindIndexInUserTable();

            // Check if user exists before creation
            if (indexExists != -1)
            {
                PrintMessage(message, ConsoleColor.Red);
                return true;
            }
            return false;
        }

        private static int ValidateIndex(string message)
        {
            int indexExists = FindIndexInUserTable();

            // Check for free slot for user creation OR for user to delete
            if (indexExists == -1)
            {
                PrintMessage(message, ConsoleColor.Red);
                return -1;
            }

            return indexExists;
        }

        private static int FindIndexInUserTable()
        {
            for (index = 0; index < userTable.GetLength(0); index++)
            {
                if (IsIndexLocated())
                {
                    parameters.Clear();

                    return index;
                }
            }

            parameters.Clear();

            return -1;
        }

        // Is used in FindIndexInUserTable's loop to determine what if check to perform
        private static bool IsIndexLocated()
        {
            // Check for null slot
            if (parameters[0] == "null")
            {
                return userTable[index, 0] == null;
            }
            // Check for existing username
            else if (parameters.Count == 1)
            {
                return userTable[index, 0] == parameters[0];
            }
            // Check for existing username and password
            else
            {
                return userTable[index, 0] == parameters[0] &&
                    userTable[index, 1] == parameters[1];
            }
        }

        private static bool ValidateArguements(string[] commandArgs)
        {
            // Validate arguments length
            if (commandArgs.Length < 3)
            {
                PrintMessage("Too few parameters", ConsoleColor.Red);
                return false;
            }

            // Validate username
            if (commandArgs[1].Length < 3)
            {
                PrintMessage("Username must be at least 3 characters long.", ConsoleColor.Red);
                return false;
            }


            // Validate password
            if (commandArgs[2].Length < 3)
            {
                PrintMessage("Password must be at least 3 characters long.", ConsoleColor.Red);
                return false;
            }

            return true;
        }

        private static void PrintMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}
