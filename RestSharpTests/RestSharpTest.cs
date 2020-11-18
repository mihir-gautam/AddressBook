using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTests
{
    public class Contacts
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    [TestClass]
    public class RestSharpTest
    {
        List<Contacts> contacts;
        RestClient client;
        private IRestResponse getContactList()
        {
            client = new RestClient("http://localhost:4000");
            var request = new RestRequest("Contacts", Method.GET);
            var restResponse = client.Execute(request);
            contacts = JsonConvert.DeserializeObject<List<Contacts>>(restResponse.Content);
            return restResponse;
        }
        /// <summary>
        /// Test method to check if contacts are retrieved from json-server
        /// </summary>
        [TestMethod]
        public void OnCallingList_UsingRestSharp_ShouldReturnContactsCount_fromJsonFile()
        {
            var response = getContactList();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var dataResponse = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            Assert.AreEqual(4, dataResponse.Count);
        }
        /// <summary>
        /// UC23 Test method passed when contact is added to json server
        /// </summary>
        [TestMethod]
        public void GivenContact_OnPost_ShouldReturn_ContactAddedToJson()
        {
            var res = getContactList();
            var request = new RestRequest("contacts", Method.POST);
            var contact = new Contacts { FirstName = "Mohit",
                                         LastName = "Verma",
                                         Address = "2913-VijayNagar",
                                         City = "knp",
                                         State = "UP",
                                         ZipCode = "202020",
                                         Phone  = "9821242545",
                                         Email  = "mohit@gmail.com" };

            var jObjectBody = new JObject();
            jObjectBody.Add("FirstName", contact.FirstName);
            jObjectBody.Add("LastName", contact.LastName);
            jObjectBody.Add("Address", contact.Address);
            jObjectBody.Add("ZipCode", contact.ZipCode);
            jObjectBody.Add("City", contact.City);
            jObjectBody.Add("State", contact.State);
            jObjectBody.Add("Phone", contact.Phone);
            jObjectBody.Add("Email", contact.Email);
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
            var response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            var dataResponse = JsonConvert.DeserializeObject<Contacts>(response.Content);
            Assert.AreEqual("Mohit", dataResponse.FirstName);
        }
    }
}
