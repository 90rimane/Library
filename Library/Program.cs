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

        }
    }
    class Library
    {
        Employee[] employee = new Employee[20];     // defult number of employees: 20 persons
        private void AddEmployee()
        {
            string name;
            int age;
            int maxAgeLimit = 65;
            int minAgeLimit = 18;

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
                    if(age > minAgeLimit && age < maxAgeLimit)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Employees age is invalid");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
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

    }
}
