using System;
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
            AddEmployee();
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
            Console.WriteLine("####### ADD EMPLOYEE #######");
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
            Console.WriteLine("\n" +
                "The new Employee added as:\n" +
                "Name:       {0}\n" +
                "Age:        {1}\n" +
                "Gender:     {2}\n" +
                "Email:      {3}\n" +
                "login pass: {4}",name,age,gender,email,pass);
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

    }
}
