﻿using System;
using MylibraryLibrary;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            admin.RunAdmin();
            Console.ReadKey(true);
        }
    }
    public class Admin
    {
        readonly Person[] employee = new Person[20];     // defult number of employees: 20 persons
        public void RunAdmin()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("###### Hallo Admin ######");
                Console.WriteLine("\nWhat you want to do:\n" +
                                      "[A] Add Employee\n" +
                                      "[R] Remove Employee\n" +
                                      "[L] List Employee\n" +
                                      "[E] Exit");
                ConsoleKeyInfo inputFromUser = Console.ReadKey(true);
                switch (inputFromUser.Key)                                  //switch case för huvud meny
                {
                    // Add Employee
                    case ConsoleKey.A:
                        {
                            AddEmployee();
                            break;
                        }

                    // tabort passagerar
                    case ConsoleKey.R:
                        {
                            RemoveEmployee();
                            break;
                        }
                    // passagerar
                    case ConsoleKey.L:
                        {
                            ListEmployee();
                            break;
                        }
                    case ConsoleKey.E:
                        {
                            Environment.Exit(0);
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose something in the menu");
                            break;
                        }
                }
            }
        }
        private void AddEmployee()
        {
            int id;
            string name;
            string gender = "Y";
            ConsoleKeyInfo inputGender;
            string email;
            string path = @"C:\Users\Rima\Desktop\Uppgift01\Library\EmployeeList.csv";

            Console.Clear();
            Console.WriteLine("\t\t####### ADD EMPLOYEE #######");
            //ID number
            while (true)
            {
                Console.WriteLine("Employee's ID prefix:");
                Console.WriteLine("Enter employee's date of birth in 6 digits'yymmdd':");
                try
                {
                    int birth = Convert.ToInt32(Console.ReadLine());
                    Random randomm = new Random();
                    int randomBirth = randomm.Next(100, 999);
                    id = birth + randomBirth;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //Write name
            while (true)
            {
                Console.WriteLine("Employee name:");
                try
                {
                    name = Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //Enter gender
            while (true)
            {
                Console.WriteLine("Enter Employee's gender: Female= X / Male= Y");
                try
                {
                    inputGender = Console.ReadKey(true);       // get input from user as ConsoleKeyInfo
                    gender = inputGender.Key.ToString();       // Convert ConsoleKeyInfo to string
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (gender == "X" || gender == "Y")
                {
                    Console.WriteLine(gender);
                    break;
                }
                else
                {
                    Console.WriteLine("Enter only X or Y");
                }
            }
            //Enter email
            while (true)
            {
                Console.WriteLine("Enter Employee's Email:");
                try
                {
                    email = Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //Random log in pass
            Random random = new Random();
            int pass = random.Next(10000, 99999);

            //
            for (int i = 0; i < employee.Length - 1; i++)       ////'-1' used to get the array index instead of the employees number on the list
            {
                if (employee[i] == null)
                {
                    employee[i] = new Person(id, name, gender, email, pass);
                    break;
                }
                else
                {
                    continue;
                }
            }

            Person emplo = new Person(id, name, gender, email, pass);
            Console.WriteLine("\n" +
                "The new Employee added as:\n" +
                "ID:         {0}\n" +
                "Name:       {1}\n" +
                "Gender:     {2}\n" +
                "Email:      {3}\n" +
                "login pass: {4}", id, name, emplo.GenderPronoum(emplo.Gender), email, pass);



            //string nameDetails = id + "," + name + "," + emplo.GenderPronoum(emplo.Gender) + "," + email + "," + pass;

            //if (!File.Exists(path))
            //{
            //    string nameHeader = "ID" + "," + "Name" + "," + "Gender" + "," + "Email" + "," + "Login Pass" + Environment.NewLine;
            //    File.WriteAllText(path, nameHeader);
            //}

            //File.AppendAllText(path, nameDetails + Environment.NewLine);

            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine (id + "," +name + "," + gender+ "," + email + "," + pass);




            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
        private void ListEmployee()
        {
            string path = @"C:\Users\Rima\Desktop\Uppgift01\Library\EmployeeList.csv";

            var lines = File.ReadLines(path);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
        private void RemoveEmployee()
        {
            string path = @"C:\Users\Rima\Desktop\Uppgift01\Library\EmployeeList.csv";

            string[] values = File.ReadAllText(path).Split(new char[] { ',' });
            StringBuilder ObjStringBuilder = new StringBuilder();
            Console.WriteLine("Enter name:");
            string input = Console.ReadLine();
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Contains(input))
                    continue;
                ObjStringBuilder.Append(values[i] + ",");
            }
            ObjStringBuilder.ToString().Remove(ObjStringBuilder.Length - 1);
            File.WriteAllText(path, ObjStringBuilder.ToString());


        }
    }
    public class Employee
    {
        public void RunEmployee()
        {

        }
    }
}