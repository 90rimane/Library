using System;
using System.Collections.Generic;
using System.Text;

namespace MylibraryLibrary
{
    public class Person
    {
        public Person(int id, string name, string gender, string email, int pass)
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
        public bool IsAdmin { get; set; }

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
