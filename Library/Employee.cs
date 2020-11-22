using MylibraryLibrary;
using System;
using System.IO;

namespace ConsoleApp
{
    public class Employee
    {
        public void RunEmployee()
        {
            Console.Clear();
            Console.WriteLine("\t####### Edit MY PROFILE #######\n");
            Path();
            EditEmployee();
        }
        public string Path()
        {
            //Console.WriteLine("Enter directory path:");
            //string path = Console.ReadLine();
            string path = @"C:\Users\Rima\Desktop\Uppgift01\Library\EmployeeList.csv";
            return path;
        }
        public void EditEmployee()
        {
            string EmpInf = GetEmployeeInfo(); //900856 , 910641
            Console.WriteLine("ID number belongs to:\n" + EmpInf);

            Console.WriteLine("Enter old name to be removed:");
            string oldName = Console.ReadLine();

            Console.WriteLine("Enter new name:");
            string newName = Console.ReadLine();

            Console.WriteLine("{0} Replaced to {1}.",oldName,newName);
            string reName = EmpInf.Replace(oldName, newName);//3 tedade hazv shodande

            File.AppendAllText(Path(), reName + Environment.NewLine);
            

            Console.ReadKey();
        }
        private String GetEmployeeInfo()
        {
            Console.WriteLine("Enter your ID number:");
            String searchName = Console.ReadLine();
            var strLines = File.ReadLines(Path());
            foreach (var line in strLines)
            {
                
                if (line.Split(',')[0].Equals(searchName))
                {
                    return line.Split(',')[0] + "," + line.Split(',')[1] + "," + line.Split(',')[2] + "," + line.Split(',')[3] + "," + line.Split(',')[4];
                    
                }
            }
            return "";
        }
    }
}
