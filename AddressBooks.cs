using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        public Contact EditPersonDetails()
        {
            string firstName = Console.ReadLine();
            Contact editedContact = FindPerson(firstName);
            if (editedContact == null)
            {
                Console.WriteLine("Address for {0} count not be found.", firstName);
                return null;
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
                return editedContact;
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
                string byName = contact.ToString();
                SortedByName.Add(byName);
            }
            SortedByName.Sort();
            foreach (string c in SortedByName)
            {
                Console.WriteLine(c);
            }
        }
        public void SortByCity()
        {
            contactList.Sort(new Comparison<Contact>((x, y) => string.Compare(x.City, y.City)));
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.Phone + "\t" + c.Email);
            }
        }
        public void SortByState()
        {
            contactList.Sort(new Comparison<Contact>((x, y) => string.Compare(x.State, y.State)));
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.Phone + "\t" + c.Email);
            }
        }
        public void SortByZip()
        {
            contactList.Sort(new Comparison<Contact>((x, y) => string.Compare(x.ZipCode, y.ZipCode)));
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.FirstName + "\t" + c.LastName + "\t" + c.Address + "\t" + c.City + "\t" + c.State + "\t" + c.ZipCode + "\t" + c.Phone + "\t" + c.Email);
            }
        }
        public void ReadFromStreamReader()
        {
            string path = @"C:\Users\Mihir Gautam\source\repos\AddressBook\AddressBookTextFile.txt";
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    String fileData;
                    while ((fileData = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine((fileData));
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        public void WriteWithStreamWriter(string bookName)
        {
            string path = @"C:\Users\Mihir Gautam\source\repos\AddressBook\AddressBookTextFile.txt";
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (Contact contact in contactList)
                    {
                        streamWriter.Write("\n"+contact.FirstName);
                        streamWriter.Write("\t "+contact.LastName);
                        streamWriter.Write("\t "+contact.Address);
                        streamWriter.Write("\t "+contact.City);
                        streamWriter.Write("\t "+contact.State);
                        streamWriter.Write("\t "+contact.Phone);
                        streamWriter.Write("\t "+contact.Email);
                    }
                    streamWriter.Close();
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        public static void ImplementCSVDataHandling()
        {
            string filePath = @"C:\Users\Mihir Gautam\source\repos\AddressBook\addressBookContacts.csv";
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                Console.WriteLine("Data Reading done successfully from contact.csv file");
                foreach (Contact contact in records)
                {
                    Console.Write("\t" + contact.FirstName);
                    Console.Write("\t" + contact.LastName);
                    Console.Write("\t" + contact.Address);
                    Console.Write("\t" + contact.City);
                    Console.Write("\t" + contact.State);
                    Console.Write("\t" + contact.ZipCode);
                    Console.Write("\t" + contact.Phone);
                    Console.Write("\t" + contact.Email);
                    Console.Write("\n");
                }
            }
        }
        public static void WriteCSVFile(List<Contact> data)
        {
            string filePath = @"C:\Users\Mihir Gautam\source\repos\AddressBook\addressBookContacts.csv";
            using (var writer = new StreamWriter(filePath))
            using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                Console.WriteLine("Data Writing done successfully from contact.csv file");
                csvWrite.WriteRecords(data);
            }
        }
        //Reading a JSON File
        public static void ReadJsonFile()
        {
            string filePath = @"C:\Users\Mihir Gautam\source\repos\AddressBook\addressBookContacts.json";
            if (File.Exists(filePath))
            {
                IList<Contact> contactsRead = JsonConvert.DeserializeObject<IList<Contact>>(File.ReadAllText(filePath));
                foreach (Contact contact in contactsRead)
                {
                    Console.Write("\t" + contact.FirstName);
                    Console.Write("\t" + contact.LastName);
                    Console.Write("\t" + contact.Address);
                    Console.Write("\t" + contact.City);
                    Console.Write("\t" + contact.State);
                    Console.Write("\t" + contact.ZipCode);
                    Console.Write("\t" + contact.Phone);
                    Console.Write("\t" + contact.Email);
                    Console.Write("\n");
                }
            }
            else
            {
                Console.WriteLine("File doesn't exists");
            }
        }
        //Writing to a JSON File
        public static void WriteToJsonFile(List<Contact> data)
        {
            string filePath = @"C:\Users\Mihir Gautam\source\repos\AddressBook\addressBookContacts.json";
            if (File.Exists(filePath))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, data);
                }
            }
            else
            {
                Console.WriteLine("File doesn't exists");
            }
        }
    }
}
