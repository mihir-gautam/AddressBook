using AddressBook;
using AddressBookSystem;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        AddressBooks book;
        public Program()
        {
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
                ArrayList ContactList = new ArrayList();
                Dictionary<string, ArrayList> Book = new Dictionary<string, ArrayList>();
                Console.WriteLine("Enter new address book name : ");
                BookName = Console.ReadLine();
                Console.WriteLine("Select the option. \n1. Add new contact. \n2. Edit existing contact. \n3. Delete existing contact \n4. Exit.");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            newProgram.book.AddPerson();
                            Book.Add(BookName, ContactList);
                            Console.WriteLine("Contact added!");
                            Console.WriteLine("New count of contacts in address book : " + Book.Count);
                            break;
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
                            exist = false;
                            break;
                        }
                }
            }
        }
    }
}

