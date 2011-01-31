﻿using System;
using System.Collections.Generic;
using System.Text;
using StringSerializer;

namespace TestApplication
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Income { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = @"Some Guy                               4550000.00 ";
            FixedWidthString fws = new FixedWidthString();
            fws.Fields = new FixedWidthField[3];
            fws.Fields[0] = new FixedWidthField(0, 30, "Name");
            fws.Fields[1] = new FixedWidthField(39, 2, "Age", typeof(int));
            fws.Fields[2] = new FixedWidthField(41, 9, "Income", "System.Decimal");

            Person person = fws.Deserialize<Person>(input);
            Console.WriteLine(String.Format("Name: {0}, Age: {1}, Income {2}", person.Name, person.Age, person.Income));
            Console.WriteLine(String.Format("|{0}| <-- Original", input));
            Console.WriteLine(String.Format("|{0}| <-- Generated", fws.Serialize(person)));
            Console.ReadKey();
        }
    }
}