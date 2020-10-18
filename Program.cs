using AddressBook;
using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        AddressBooks book;
        public HashSet<Contact> ContactSet;
        public Program()
        {
            ContactSet = new HashSet<Contact>();
            book = new AddressBooks();
        }
        static void Main(string[] args)
        {
            Program newProgram = new Program();
            Console.WriteLine("Welcome to the Address Book Program!");
            bool exist = true;
            while (exist)
            {
                string BookName;
                HashSet<Contact> ContactSet = new HashSet<Contact>();
                Dictionary<string, HashSet<Contact>> Book = new Dictionary<string, HashSet<Contact>>();

                Console.WriteLine("Enter new address book name : ");
                BookName = Console.ReadLine();
                Console.WriteLine("Select the option. \n1. Add new contact. \n2. Edit existing contact. \n3. Delete existing contact \n4. Search a contact" +
                    "by city \n 5. Search a contact by state \n6. Exit.");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            newProgram.book.AddPerson();
                            if (newProgram.book.CheckDuplicate())
                            { break; }
                            else
                            {
                                Book.Add(BookName, ContactSet);
                                Console.WriteLine("Contact added!");
                                Console.WriteLine("New count of contacts in address book : " + Book.Count);
                                break;
                            }
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the first name of that person: ");
                            newProgram.book.EditPersonDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the first name of that person: ");
                            newProgram.book.DeletePersonDetails();
                            Console.WriteLine("New count of contacts in address book : " + Book.Count);
                            break;
                        }
                    case 4:
                        {
                            SearchContacts.SearchByCity();
                            break;
                        }
                    case 5:
                        {
                            SearchContacts.SearchByState();
                            break;
                        }
                    case 6:
                        {
                            exist = false;
                            break;
                        }
                }
            }
        }
    }
}

