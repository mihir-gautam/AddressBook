using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class MultipleAddressBooks
    {
        Dictionary<string, AddressBooks> addressBooksCollection = new Dictionary<string, AddressBooks>();
        public Dictionary<string, List<Contact>> ContactByCity;
        public Dictionary<string, List<Contact>> ContactByState;
        List<string> cities;
        List<string> states;
        public MultipleAddressBooks()
        {
            addressBooksCollection = new Dictionary<string, AddressBooks>();
        }
        public void AddAddressBook(string name)
        {
            AddressBooks addressBook = new AddressBooks();
            addressBooksCollection.Add(name, addressBook);

        }
        public AddressBooks GetAddressBook(string name)
        {
            if (addressBooksCollection.ContainsKey(name))
            {
                return addressBooksCollection[name];
            }
            return null;
        }
        public void SearchPersonOverMultipleAddressBook(string city)
        {
            Dictionary<string, AddressBooks>.Enumerator enumerator = addressBooksCollection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("AddressBook Name :" + enumerator.Current.Key);
                Console.WriteLine();
                enumerator.Current.Value.SearchContactByCity(city);
                Console.WriteLine("-------------------------");
            }
        }
        public void GetDistinctCityAndStateList()
        {
            foreach (var addressBook in addressBooksCollection)
            {
                foreach (var contact in addressBook.Value.contactList)
                {
                    if (cities.Contains(contact.City) == false)
                    {
                        cities.Add(contact.City);
                    }
                    if (states.Contains(contact.State) == false)
                    {
                        states.Add(contact.State);
                    }

                }
            }
        }
        public void SetContactByCityDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string city in cities)
            {
                List<Contact> contacts = new List<Contact>();
                foreach (var addressBook in addressBooksCollection)
                {
                    contacts.AddRange(addressBook.Value.GetContactByCity(city));
                }
                if (ContactByCity.ContainsKey(city))
                {
                    ContactByCity[city] = contacts;
                }
                else
                {
                    ContactByCity.Add(city, contacts);
                }
            }

        }
        public void SetContactByStateDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string state in states)
            {
                List<Contact> contacts = new List<Contact>();
                foreach (var addressBook in addressBooksCollection)
                {
                    contacts.AddRange(addressBook.Value.GetContactByState(state));
                }
                if (ContactByState.ContainsKey(state))
                {
                    ContactByState[state] = contacts;
                }
                else
                {
                    ContactByState.Add(state, contacts);
                }
            }

        }
        public void ViewPersonsByCity(string city)
        {
            if (ContactByCity.ContainsKey(city))
            {
                foreach (Contact contact in ContactByCity[city])
                {
                    Console.WriteLine("Name :" + contact.FirstName + " " + contact.LastName + "\nAddress :" + contact.Address + "   ZipCode :" + contact.ZipCode + "\nPhone No :" + contact.Phone + "   Email :" + contact.Email);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
        public void ViewPersonsByState(string state)
        {
            if (ContactByState.ContainsKey(state))
            {
                foreach (Contact contact in ContactByState[state])
                {
                    Console.WriteLine("Name :" + contact.FirstName + " " + contact.LastName + "\nAddress :" + contact.Address + "   ZipCode :" + contact.ZipCode + "\nPhone No :" + contact.Phone + "   Email :" + contact.Email);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }

    }
}
