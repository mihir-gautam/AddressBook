using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AddressBook
{
    public class AddressBooks
    {
        public List<Contact> contactList;
        public HashSet<Contact> ContactSet = new HashSet<Contact>();
        List<Contact> Person = new List<Contact>();
        HashSet<string> ContactName = new HashSet<string>();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public AddressBooks()
        {
            contactList = new List<Contact>();

        }

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

            contactList.Add(contact);
        }
        public bool CheckDuplicate()
        {
            if (ContactName.Contains(FirstName) && ContactName.Contains(LastName))
            {
                Console.WriteLine("Contact details for this person already stored.");
                return true;
            }
            else
            {
                return false;
            }
        }
        public Contact FindPerson(string firstName)
        {
            Contact toFind = contactList.Find((person) => person.FirstName == firstName);
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
        public void DeletePersonDetails()
        {
            string firstName = Console.ReadLine();
            Contact deleteContact = FindPerson(firstName);
            if (deleteContact == null)
            {
                Console.WriteLine("Address for {0} count not be found.", firstName);
            }
            else
            {
                contactList.Remove(deleteContact);
                Console.WriteLine("Existing contact details of {0} has been deleted succesfully", firstName);
            }
        }
        public void SearchContactByCity(string city)
        {

            foreach (var contact in contactList)
            {
                if (contact.City == city)
                {
                    Console.WriteLine("Name :" + contact.FirstName + " " + contact.LastName + "\nAddress :" + contact.Address + "   ZipCode :" + contact.ZipCode + "\nPhone No :" + contact.Phone + "   Email :" + contact.Email);
                }
            }

        }
        public void SearchContactByState(string state)
        {

            foreach (var contact in contactList)
            {
                if (contact.State == state)
                {
                    Console.WriteLine("Name :" + contact.FirstName + " " + contact.LastName + "\nAddress :" + contact.Address + "   ZipCode :" + contact.ZipCode + "\nPhone No :" + contact.Phone + "   Email :" + contact.Email);
                }
            }

        }
        public List<Contact> GetContactByCity(string city)
        {
            List<Contact> contact = new List<Contact>();
            foreach (Contact c in contactList)
            {
                if (c.City.Equals(city))
                    contact.Add(c);

            }
            return contact;
        }
        public List<Contact> GetContactByState(string State)
        {
            List<Contact> contact = new List<Contact>();
            foreach (Contact c in contactList)
            {
                if (c.State.Equals(State))
                    contact.Add(c);

            }
            return contact;
        }
        public void SortByNameInAlphabeticalOrder()
        {
            List<string> SortedByName = new List<string>();
            foreach (Contact contact in contactList)
            {
                string name = contact.FirstName.ToString();
                SortedByName.Add(name);
            }
            SortedByName.Sort();
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.Phone + "\t" + c.Email);
            }
        }
        public void SortByCity()
        {
            List<string> SortedByCity = new List<string>();
            foreach (Contact contact in contactList)
            {
                string city = contact.City.ToString();
                SortedByCity.Add(city);
            }
            SortedByCity.Sort();
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.Phone + "\t" + c.Email);
            }
        }
        public void SortByState()
        {
            List<string> SortedByState = new List<string>();
            foreach (Contact contact in contactList)
            {
                string city = contact.City.ToString();
                SortedByState.Add(city);
            }
            SortedByState.Sort();
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.Phone + "\t" + c.Email);
            }
        }
        public void SortByZip()
        {
            List<string> SortedByZip = new List<string>();
            foreach (Contact contact in contactList)
            {
                string zip = contact.ZipCode.ToString();
                SortedByZip.Add(zip);
            }
            SortedByZip.Sort();
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.Phone + "\t" + c.Email);
            }
        }
    }
}
