using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                GetNumberOfContacts(CityDictionary.Count);
            }
            foreach (var element in ContactsByCity)
            {
                Console.WriteLine(element);
            }
            return SearchByCity();
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
                GetNumberOfContacts(StateDictionary.Count);
            }
            foreach (var element in ContactsByState)
            {
                Console.WriteLine(element);
            }
            return SearchByState();
        }
        public static void GetNumberOfContacts(int count)
        {
            Console.WriteLine("Number of contacts : "+count); 
        }
    }
}
