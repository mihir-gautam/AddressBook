using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class SearchContacts
    {
        public Dictionary<string, HashSet<Contact>> GeneralDictionary = new Dictionary<string, HashSet<Contact>>();


        public static List<Contact> SearchByCity()
        {
            Contact contact = new Contact();
            List<Contact> ContactsByCity = new List<Contact>();
            Dictionary<string, List<Contact>> CityDictionary = new Dictionary<string, List<Contact>>();
            Console.WriteLine("Enter the city: ");
            string city = Console.ReadLine();
            if (contact.City == city)
            {
                ContactsByCity.Add(contact);
                CityDictionary.Add(city, ContactsByCity);
            }
            Console.WriteLine(ContactsByCity);
            return ContactsByCity;
        }
        public static List<Contact> SearchByState()
        {
            Contact contact = new Contact();
            List<Contact> ContactsByState = new List<Contact>();
            Dictionary<string, List<Contact>> StateDictionary = new Dictionary<string, List<Contact>>();
            Console.WriteLine("Enter the state: ");
            string state = Console.ReadLine();
            if (contact.State == state)
            {
                ContactsByState.Add(contact);
                StateDictionary.Add(state, ContactsByState);
            }
            Console.WriteLine(ContactsByState);
            return ContactsByState;
        }
    }
}
