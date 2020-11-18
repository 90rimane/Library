using System;
using MylibraryLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            admin.Run();
            Console.ReadKey(true);
        }
    }
}