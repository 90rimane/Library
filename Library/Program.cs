using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var admin = new Library();
            admin.Run();
            //Console.ReadKey(true);
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
            int id;
            string name;
            string gender = "Y";
            ConsoleKeyInfo inputGender;
            string email;            

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
                    employee[i] = new Employee(id,name,gender,email,pass);
                    break;
                }
                else
                {
                    continue;
                }
            }

            Employee emplo = new Employee(id,name,gender,email,pass);          
            Console.WriteLine("\n" +
                "The new Employee added as:\n" +
                "ID:         {0}\n" +
                "Name:       {1}\n" +
                "Gender:     {2}\n" +
                "Email:      {3}\n" +
                "login pass: {4}", id, name, emplo.GenderPronoum(emplo.Gender), email, pass);


            string newFileName = @"C:\Users\Rima\Desktop\Uppgift01\Library\EmployeeList.csv";
            string nameDetails = id + "," + name + "," + emplo.GenderPronoum(emplo.Gender)+","+ email +","+ pass;
           
            if (!File.Exists(newFileName))
            {
                string nameHeader = "ID" + "," +"Name" + "," +"Gender"+","+"Email"+","+"Login pass" + Environment.NewLine;
                File.WriteAllText(newFileName, nameHeader);
            }
           
            File.AppendAllText(newFileName, nameDetails + Environment.NewLine);

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
        public Employee(int id,string name, string gender, string email, int pass)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Email = email;
            Pass = pass;
        }
        public int Id { get; set; }
        public string Name { get; set; }
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
