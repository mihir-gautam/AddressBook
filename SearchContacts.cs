using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class SearchContacts
    {
        public Dictionary<string, HashSet<Contact>> GeneralDictionary = new Dictionary<string, HashSet<Contact>>();

        public Dictionary<string, List<Contact>> CityDictionary = new Dictionary<string, List<Contact>>();

        public static List<Contact> SearchByCity()
        {
            Contact contact = new Contact();
            List<Contact> ContactsByCity = new List<Contact>();
            Console.WriteLine("Enter the city: ");
            string city = Console.ReadLine();
            if (contact.City == city)
            {
                ContactsByCity.Add(contact);
            }
            Console.WriteLine(ContactsByCity);
            return ContactsByCity;
        }
    }
}
