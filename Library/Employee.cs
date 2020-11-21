using MylibraryLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Employee
    {
        string path = @"C:\Users\Rima\Desktop\Uppgift01\Library\EmployeeList.csv";
        public void RunEmployee()
        {
            List<String> lines = new List<String>();
            StreamReader reader = new StreamReader(File.OpenRead(path));
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(","))
                    {
                        String[] split = line.Split(',');

                        if (split[1] == "abc")//condition for Edit record like : split[1] == "abc" etc.
                        {
                            //update that
                            split[1] = "xyz";
                            line = String.Join(",", split);
                            lines.Add(line);
                        }
                        if (!File.Exists(path))//condition for Delete row.
                        {
                            //don't add that row into string list
                        }
                    }

                }
            }

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (String line in lines)
                    writer.WriteLine(line);
            }

        }


    }

}