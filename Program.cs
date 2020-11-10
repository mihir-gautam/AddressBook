using AddressBook;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookConnectionToDB dataFromDB = new AddressBookConnectionToDB();
            AddressBooks addressBooks = new AddressBooks();
            Console.WriteLine("Enter your choice: \n1.Show all contacts in the database \n2.Update database contact table \n3.Delete a contact");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    dataFromDB.RetrieveFromDatabase();
                    break;
                case 2:
                    Console.WriteLine("Enter FirstName");
                    Contact contact = addressBooks.EditPersonDetails();
                    dataFromDB.UpdateContact(contact);
                    break;
                case 3:
                    Console.WriteLine("Enter Start date");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter End date");
                    DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                    dataFromDB.DeleteContacts(startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                    break;
            }

            //int choice = 0;
            //bool flag = true;
            //string addBookName = "";

            //MultipleAddressBooks multipleAddressBooks = new MultipleAddressBooks();
            //AddressBooks addressBook = null;
            //Console.WriteLine("Welcome to the Address Book Program!");
            //while (true)
            //{

            //    Console.WriteLine("1.Add Address Book\n2.Open Address Book");
            //    choice = Convert.ToInt32(Console.ReadLine());

            //    switch (choice)
            //    {
            //        case 1:
            //            Console.WriteLine("Enter name of Address Book");
            //            addBookName = Console.ReadLine();
            //            multipleAddressBooks.AddAddressBook(addBookName);
            //            addressBook = multipleAddressBooks.GetAddressBook(addBookName);
            //            flag = true;
            //            break;
            //        case 2:
            //            Console.WriteLine("Enter name of Address Book");
            //            addBookName = Console.ReadLine();
            //            addressBook = multipleAddressBooks.GetAddressBook(addBookName);
            //            flag = true;
            //            if (addressBook == null)
            //            {
            //                Console.WriteLine("No such Address Book");
            //                flag = false;
            //            }
            //            break;
            //        default:
            //            flag = false;
            //            Console.WriteLine("Invalid Choice");
            //            break;
            //    }
            //    bool exist = true;
            //    while (exist)
            //    {
            //        Console.WriteLine("Select the option. \n1. Add new contact. \n2. Edit existing contact. \n3. Delete existing contact \n4. Search a contact" +
            //            " by city \n5. Search a contact by state \n6. Count By City \n7. Count By State \n8. Show contacts in alphabetical order \n9. Sort by City" +
            //            " \n10. Sort by state \n11. Sort by zipcode \n12. Exit");
            //        int option = int.Parse(Console.ReadLine());
            //        switch (option)
            //        {
            //            case 1:
            //                {
            //                    addressBook.AddPerson();
            //                    if (addressBook.CheckDuplicate())
            //                    { break; }
            //                    else
            //                    { 
            //                        Console.WriteLine("Contact added!");
            //                        break;
            //                    }
            //                }
            //            case 2:
            //                {
            //                    Console.WriteLine("Enter the first name of that person: ");
            //                    addressBook.EditPersonDetails();
            //                    break;
            //                }
            //            case 3:
            //                {
            //                    Console.WriteLine("Enter the first name of that person: ");
            //                    addressBook.DeletePersonDetails();
            //                    break;
            //                }
            //            case 4:
            //                {
            //                    Console.WriteLine("Enter the city: ");
            //                    string city = Console.ReadLine();
            //                    multipleAddressBooks.SearchPersonOverMultipleAddressBook(city);
            //                    break;
            //                }
            //            case 5:
            //                {
            //                    Console.WriteLine("Enter the state: ");
            //                    string state = Console.ReadLine();
            //                    multipleAddressBooks.SearchPersonOverMultipleAddressBook(state);
            //                    break;
            //                }
            //            case 6:
            //                multipleAddressBooks.SetContactByCityDictionary();
            //                foreach (var contactByCity in multipleAddressBooks.ContactByCity)
            //                {
            //                    Console.WriteLine("City :" + contactByCity.Key + "   Count :" + contactByCity.Value.Count);

            //                }
            //                break;
            //            case 7:
            //                multipleAddressBooks.SetContactByStateDictionary();
            //                foreach (var contactByState in multipleAddressBooks.ContactByState)
            //                {
            //                    Console.WriteLine("State :" + contactByState.Key + "   Count :" + contactByState.Value.Count);

            //                }
            //                break;
            //            case 8:
            //                {
            //                    addressBook.SortByNameInAlphabeticalOrder();
            //                    break;
            //                }
            //            case 9:
            //                {
            //                    addressBook.SortByCity();
            //                    break;
            //                }
            //            case 10:
            //                {
            //                    addressBook.SortByState();
            //                    break;
            //                }
            //            case 11:
            //                {
            //                    addressBook.SortByZip();
            //                    break;
            //                }
            //            case 12:
            //                {
            //                    exist = false;
            //                    break;
            //                }
            //        }
            //        addressBook.WriteWithStreamWriter(addBookName);
            //        Console.WriteLine("Contact details have been written to file successfully");
            //        addressBook.ReadFromStreamReader();
            //        AddressBooks.ImplementCSVDataHandling();
            //        AddressBooks.WriteCSVFile(addressBook.contactList);
            //        AddressBooks.WriteToJsonFile(addressBook.contactList);
            //        AddressBooks.ReadJsonFile();


            //    }
            //}
        }
    }
}

