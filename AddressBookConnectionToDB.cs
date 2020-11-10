using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook
{
    public class AddressBookConnectionToDB
    {
        string connectionString = @"Data Source=.;Initial Catalog=address_book_service;Integrated Security=True";
        SqlConnection connection;
        List<Contact> contactList = new List<Contact>();
        int count;
        public bool RetrieveFromDatabase()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = "select * from Contact_Info contact inner join Contact_Type type on(contact.FirstName = type.FirstName)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    this.connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Contact contact = new Contact();
                            contact.FirstName = reader.GetString(0);
                            contact.LastName = reader.GetString(1);
                            contact.Address = reader.GetString(2);
                            contact.City = reader.GetString(3);
                            contact.State = reader.GetString(4);
                            contact.ZipCode = reader.GetString(5);
                            contact.Phone = reader.GetString(6);
                            contact.Email = reader.GetString(7);
                            contact.BookName = reader.GetString(8);
                            contact.ContactType = reader.GetString(9); 

                            contactList.Add(contact);

                            Console.WriteLine(  "  " + contact.FirstName + 
                                                "  " + contact.LastName + 
                                                "  " + contact.Address +
                                                "  " + contact.City +
                                                "  " + contact.State +
                                                "  " + contact.ZipCode + 
                                                "  " + contact.Phone + 
                                                "  " + contact.Email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Table is empty");
                    }
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public bool UpdateContact(Contact contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"Update Contact_Info set PhoneNumber = '" + contact.Phone + "/, Email = -" + contact.Email +
                                    "/ where FirstName = -" + contact.FirstName + "/ and LastName = -" + contact.LastName + "/";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
