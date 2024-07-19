using Name.model;
using Name.business;
using System;

namespace Name
{
    class Program
    {
        static InfoServices infoServices = new InfoServices();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Info");
                Console.WriteLine("2. Update Info");
                Console.WriteLine("3. Delete Info");
                Console.WriteLine("4. Show All Infos");
                Console.WriteLine("5. Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        AddInfoItem();
                        break;
                    case 2:
                        UpdateInfoItem();
                        break;
                    case 3:
                        DeleteInfoItem();
                        break;
                    case 4:
                        DisplayAllInfos();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddInfoItem()
        {
            Console.WriteLine("Enter Info Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Info Description:");
            string description = Console.ReadLine();

            Info newInfo = new Info
            {
                Name = name,
                Description = description
            };

            bool success = infoServices.AddInfo(newInfo);

            if (success)
            {
                Console.WriteLine("Info added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add info.");
            }
        }

        static void UpdateInfoItem()
        {
            Console.WriteLine("Enter Info Name to update:");
            string name = Console.ReadLine();

            Info existingInfo = infoServices.GetAllInfos().Find(i => i.Name == name);

            if (existingInfo == null)
            {
                Console.WriteLine($"Info '{name}' not found.");
                return;
            }

            Console.WriteLine("Enter Updated Description:");
            string description = Console.ReadLine();

            existingInfo.Description = description;

            bool success = infoServices.UpdateInfo(existingInfo);

            if (success)
            {
                Console.WriteLine("Info updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update info.");
            }
        }

        static void DeleteInfoItem()
        {
            Console.WriteLine("Enter Info Name to delete:");
            string name = Console.ReadLine();

            bool success = infoServices.DeleteInfo(name);

            if (success)
            {
                Console.WriteLine("Info deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete info '{name}'.");
            }
        }

        static void DisplayAllInfos()
        {
            var infos = infoServices.GetAllInfos();

            if (infos.Count == 0)
            {
                Console.WriteLine("No infos found.");
            }
            else
            {
                Console.WriteLine("All Infos:");
                foreach (var info in infos)
                {
                    Console.WriteLine($"Name: {info.Name}, Description: {info.Description}");
                    // Print other details if needed
                }
            }
        }
    }
}
