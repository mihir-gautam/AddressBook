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
    }
}
