﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var admin = new Library();
            admin.Run();
            Console.ReadKey(true);
        }
    }
    class Library
    {
        Employee[] employee = new Employee[20];     // defult number of employees: 20 persons
        public void Run()
        {
            //AddEmployee();
            RemoveEmployee();
        }
        private void AddEmployee()
        {
            string name;
            int age;
            int maxAgeLimit = 65;
            int minAgeLimit = 18;
            string gender = "Y";
            ConsoleKeyInfo inputGender;
            string email;

            Console.Clear();
            Console.WriteLine("\t\t####### ADD EMPLOYEE #######");
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
                Console.WriteLine("Employee age:");
                try
                {
                    age = int.Parse(Console.ReadLine());
                    if (age >= minAgeLimit && age < maxAgeLimit)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Employee's age is invalid");
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Write an integer,please:");
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
            int pass = random.Next(1000, 9999);
            
            //
            for (int i = 0; i < employee.Length - 1; i++)
            {
                if (employee[i] == null)
                {
                    employee[i] = new Employee(name,age,gender,email,pass);
                    break;
                }
                else
                {
                    continue;
                }
            }
            Employee empl = new Employee(name,age,gender,email,pass);
            Console.WriteLine("\n" +
                "The new Employee added as:\n" +
                "Name:       {0}\n" +
                "Age:        {1}\n" +
                "Gender:     {2}\n" +
                "Email:      {3}\n" +
                "login pass: {4}",name,age, empl.GenderPronoum(empl.Gender), email,pass);
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
        private void RemoveEmployee()
        {
            int employeeNumber = 0;

            Console.Clear();
            Console.WriteLine("\t\t####### REMOVE EMPLOYEE #######");
            //Print Employee
            foreach(Employee person in employee)
            {
                employeeNumber++;
                if (person == null)
                {
                    Console.WriteLine("{0}_ Not employee registered.",employeeNumber);
                }
                else
                {
                    Console.WriteLine("{0}_ {1}",employeeNumber, person.Name);
                }
            }
            Console.WriteLine("Enter employee number from list to remove him/her from list.");
            int index;
            while (true)
            {
                index = Convert.ToInt32(Console.ReadLine()) - 1;    //'-1' used to get the array index instead of the employees number on the list
                
            }
        }
    }
    class Employee
    {
        public Employee(string name, int age, string gender, string email, int pass)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Email = email;
            Pass = pass;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int Pass { get; set; }

        public string GenderPronoum(string gender)
        {
            switch (gender)
            {
                case "X":
                    gender = "Female";
                    break;
                case "Y":
                    gender = "Male";
                    break;
            }
            return gender;
        }

    }
}
