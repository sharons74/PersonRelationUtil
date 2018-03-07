using PersonRelations.Entities;
using System;
using System.Collections.Generic;
using PersonRelations;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = GetPresons();
            PersonRelationUtil util = new PersonRelationUtil(Console.WriteLine);
            util.Init(persons);
            Person personA = persons[2];
            Person personB = persons[5];         

            Console.WriteLine($"minimal hops {util.FindMinRelationLevel(personA, personB)}");
            
            Console.ReadLine();
        }

        private static Person[] GetPresons()
        {
            List<Person> persons = new List<Person>();

            persons.Add(CreatePerson("sharon", "salmon", "ein", "iron"));
            persons.Add(CreatePerson("avi", "salmon", "ein", "ovdat"));
            persons.Add(CreatePerson("sharon", "salmon", "kfar", "vradim"));
            persons.Add(CreatePerson("eran", "salmon", "kfar", "vradim"));
            persons.Add(CreatePerson("eran", "salmon", "ein", "ovdat"));
            persons.Add(CreatePerson("sharon", "salmon", "ein", "ovdat"));
            persons.Add(CreatePerson("john", "doe", "no", "ware"));

            return persons.ToArray();           

        }

        private static Person CreatePerson(string firstName, string lastName, string city, string street)
        {

            return new Person()
            {
                Address = new Address() { City = city,Street = street},
                FullName = new Name() { FirstName = firstName,LastName = lastName}
            };
            


        }

    }
}
