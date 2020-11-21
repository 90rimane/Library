using System;
using MylibraryLibrary;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("###### Library Simulator ######");
            Console.WriteLine("\nEnter a command:\n" +
                              "[A] Admin\n" +
                              "[E] Employee\n" +
                              "[X] Exit");
            ConsoleKeyInfo inputFromUser = Console.ReadKey(true);
            switch (inputFromUser.Key)                                  //switch case för huvud meny
            {              
                case ConsoleKey.A:
                    {
                        LoginAdmin();
                                               
                        break;
                    }
                case ConsoleKey.E:
                    {
                        LoginEmployee();
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
                        break;
                    }     
            }
        }
        private static void LoginAdmin()
        {
            int UserID, password;
            int ctr = 0;
            Console.Write("\n\nAdmin Login:\n");
            Console.Write("Default ID and PassWord : 123456 and 12345\n");
            do
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Enter a ID number: ");
                        UserID = int.Parse(Console.ReadLine());

                        Console.Write("Enter a password: ");
                        password = int.Parse(Console.ReadLine());

                        if (UserID != 123456 || password != 12345)
                            ctr++;
                        else
                            ctr = 1;
                            Console.WriteLine("Invalid ID or pass word.\n");
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter in correct format");
                    }
                    
                }
            }
            while ((UserID != 123456 && password != 1234) && (ctr != 3));

            if (ctr == 3)
            {
                Console.Write("\nLogin attemp three or more times. Try later!\n\n");
                Console.ReadKey();
            }
            else
            {
                Admin admin = new Admin();
                admin.RunAdmin();
            }
        }
        private static void LoginEmployee()
        {
            int UserID, password;
            int ctr = 0;
            Console.Write("\n\nEmploye Login:\n");
            Console.Write("Default ID and PassWord : 123456 and 12345\n");
            do
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Enter a ID number: ");
                        UserID = int.Parse(Console.ReadLine());

                        Console.Write("Enter a password: ");
                        password = int.Parse(Console.ReadLine());

                        if (UserID != 123456 || password != 12345)
                            ctr++;
                        else
                            ctr = 1;
                        Console.WriteLine("Invalid ID or pass word.\n");
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter in correct format");
                    }

                }
            }
            while ((UserID != 123456 && password != 1234) && (ctr != 3));

            if (ctr == 3)
            {
                Console.Write("\nLogin attemp three or more times. Try later!\n\n");
                Console.ReadKey();
            }
            else
            {
                Employee emplo = new Employee();
                emplo.RunEmployee();
            }
        }

    }
}