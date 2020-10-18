using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    public class AddressBook
    {
        public static void AddPerson()
        {
            Contact contact = new Contact();

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City : ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State : ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip Code : ");
            contact.ZipCode = Console.ReadLine();

            Console.Write("Enter Phone Number : ");
            contact.Phone = Console.ReadLine();

            Console.Write("Enter Email ID : ");
            contact.Email = Console.ReadLine();

            List<Contact> Person = new List<Contact>();
            Person.Add(contact);
        }
    }
}