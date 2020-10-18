using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {

        List<Contact> Person = new List<Contact>();
        public void AddPerson()
        {
            Contact contact = new Contact();
            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Enter Address : ");
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

            Person.Add(contact);
        }
        public Contact FindPerson(string firstName)
        {
            Contact toFind = Person.Find((person) => person.FirstName == firstName);
            return toFind;
        }
        public void EditPersonDetails()
        {
            string firstName = Console.ReadLine();
            Contact editedContact = FindPerson(firstName);
            if (editedContact == null)
            {
                Console.WriteLine("Address for {0} count not be found.", firstName);
            }
            else
            {
                Console.WriteLine("Exisitng address for {0} found, please update the details.", firstName);
                Console.WriteLine("New Last Name");
                editedContact.LastName = Console.ReadLine();
                Console.WriteLine("New Address");
                editedContact.Address = Console.ReadLine();
                Console.WriteLine("New City");
                editedContact.City = Console.ReadLine();
                Console.WriteLine("New State");
                editedContact.State = Console.ReadLine();
                Console.WriteLine("New Zip code");
                editedContact.ZipCode = Console.ReadLine();
                Console.WriteLine("New Phone Number");
                editedContact.Phone = Console.ReadLine();
                Console.WriteLine("New Email");
                editedContact.Email = Console.ReadLine();
                Console.WriteLine("Contact details updated successfully!");
            }
        }
    }
}