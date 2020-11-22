using MylibraryLibrary;
using System;
using System.IO;

namespace ConsoleApp
{
    public class Employee
    {
        public void RunEmployee()
        {
            //Console.WriteLine(@"Enter path: EX:C:\EmployeeList.csv");
            Path();
            Console.Clear();
            Console.WriteLine("\t####### MY PROFILE #######\n");

            Console.WriteLine("Enter your ID number:");
            String searchItem = Console.ReadLine();

            string EmpInf = GetEmployeeInfo(searchItem); //
            Console.WriteLine("ID number belongs to:\n" + EmpInf);

            Console.WriteLine("\nEnter a command:\n" +
                             "[E] Edit my profile\n" +
                             "[X] Exit");
            ConsoleKeyInfo inputFromUser = Console.ReadKey(true);
            switch (inputFromUser.Key)
            {
                case ConsoleKey.E:
                    {
                        EditEmployee();

                        break;
                    }
                case ConsoleKey.X:
                    {
                        Environment.Exit(0);
                        return;
                    }
            }
        }
        public string Path()
        {
            //return @"C:\Users\Rima\Desktop\Uppgift01\Library\PersonList.csv"; //
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"PesonList.csv";
        }
        private void EditEmployee()
        {
            Console.WriteLine("\nEnter your ID number:");
            String searchItem = Console.ReadLine();

            while (true)
            {
                string EmpInf = GetEmployeeInfo(searchItem); //
                Console.Clear();
                Console.WriteLine("ID number belongs to:\n" + EmpInf);
                Console.WriteLine("\nWhat you want to do:\n" +
                      "[N] Change Name\n" +
                      "[E] Change Email\n" +
                      "[P] Change Pass\n" +
                      "[X] Exit");

                ConsoleKeyInfo inputFromUser = Console.ReadKey(true);
                switch (inputFromUser.Key)
                {
                    case ConsoleKey.N:
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\nEnter old name to remove:");
                                    string oldName = Console.ReadLine();

                                    Console.WriteLine("Enter new name");
                                    string newName = Console.ReadLine();

                                    Console.WriteLine("{0} Removed. {1} added.", oldName, newName);
                                    string reName = EmpInf.Replace(oldName, newName);

                                    File.WriteAllText(Path(), reName + Environment.NewLine);
                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Enter correct format.");
                                }
                                break;
                            }

                            break;
                        }
                    case ConsoleKey.E:
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\nEnter old email to remove:");
                                    string oldName = Console.ReadLine();

                                    Console.WriteLine("Enter new email");
                                    string newName = Console.ReadLine();

                                    Console.WriteLine("{0} Removed. {1} added.", oldName, newName);
                                    string reName = EmpInf.Replace(oldName, newName);

                                    File.WriteAllText(Path(), reName + Environment.NewLine);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Invalid format");
                                }
                                break;
                            }

                            break;
                        }
                    case ConsoleKey.P:
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\nEnter old passwor to remove:");
                                    string oldName = Console.ReadLine();

                                    Console.WriteLine("Enter new password");
                                    string newName = Console.ReadLine();

                                    Console.WriteLine("{0} Removed. {1} added.", oldName, newName);
                                    string reName = EmpInf.Replace(oldName, newName);

                                    File.WriteAllText(Path(), reName + Environment.NewLine);

                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Invalid format.");
                                }
                                    break;
                            }

                            break;
                        }
                    case ConsoleKey.X:
                        {
                            Environment.Exit(0);
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose something in the menu");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
        private String GetEmployeeInfo(string searchItem)
        {

            var strLines = File.ReadLines(Path());
            foreach (var line in strLines)
            {

                if (line.Split(',')[0].Equals(searchItem))
                {
                    line.Remove(0, line.Length);
                    return line.Split(',')[0] + "," + line.Split(',')[1] + "," + line.Split(',')[2] + "," + line.Split(',')[3] + "," + line.Split(',')[4];

                }
            }
            return "";
        }
    }
}
