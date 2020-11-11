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
        public int DeleteContacts(string startDate, string endDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int contactsDeleted = 0;
            try
            {
                using (connection)
                {
                    string query = @"delete from Contact_Info where JoiningDate between '" + startDate + "' and '" + endDate + "';";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    contactsDeleted = cmd.ExecuteNonQuery();
                    if (contactsDeleted > 0)
                    {
                        Console.WriteLine(contactsDeleted + " contacts successfully deleted");
                    }
                    else
                    {
                        Console.WriteLine("No contacts joined between those dates");
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return contactsDeleted;
        }
        public void RetrieveContactByCityOrState(string city, string state)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select * from (ContactInfo contact inner join ContactType type on (contact.ContactId = type.ContactId)) inner join Address address on address.ContactId = contact.ContactId where address.City = '" + city + "' and address.State = '" + state + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Contact contact = new Contact();
                            contact.FirstName = !dr.IsDBNull(1) ? dr.GetString(1) : "";
                            contact.LastName = !dr.IsDBNull(2) ? dr.GetString(2) : "";
                            contact.Phone = !dr.IsDBNull(3) ? dr.GetString(3) : "";
                            contact.Email = !dr.IsDBNull(4) ? dr.GetString(4) : "";
                            //contact.JoiningDate = !dr.IsDBNull(5) ? dr.GetDateTime(5) : Convert.ToDateTime("01 -01-2019");
                            contact.ContactType = !dr.IsDBNull(7) ? dr.GetString(7) : "";
                            contact.Address = !dr.IsDBNull(9) ? dr.GetString(9) : "";
                            contact.City = !dr.IsDBNull(10) ? dr.GetString(10) : "";
                            contact.State = !dr.IsDBNull(11) ? dr.GetString(11) : "";
                            contact.ZipCode = !dr.IsDBNull(12) ? dr.GetString(12) : "";
                            Console.WriteLine(contact.FirstName + "," + contact.LastName + "," 
                                            + contact.Phone + "," + contact.Email + "," 
                                            + contact.JoiningDate + "," + contact.ContactType + "," 
                                            + contact.Address + "," + contact.City + "," 
                                            + contact.State + "," + contact.ZipCode);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool AddContactToDB(Contact contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAddContactDetails", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", contact.Phone);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.Parameters.AddWithValue("@JoiningDate", contact.JoiningDate);
                    command.Parameters.AddWithValue("@Contact_Type", contact.ContactType);
                    command.Parameters.AddWithValue("@Address", contact.Address);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@State", contact.State);
                    command.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
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
