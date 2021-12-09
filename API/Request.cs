using System;
using NUnit.Framework;

namespace LabcorpAuto
{
    [TestFixture]
    [Category("API Test")]
    public class Request
    {
        [Test]
        public void PostRequest()
        {
            string endpoint = "https://6143a99bc5b553001717d06a.mockapi.io/testapi/v1//Users";
            string request = "{\"createdAt\":1631825833,\"employee_firstname\":\"John\",\"employee_lastname\":\"Ruth\",\"employee_phonenumbe\":\"264 - 783 - 9453\",\"ademployee_emaildress\":\"thehangman@gmail.com 1\",\"citemployee_addressy\":\"citemployee_addressy 1\",\"stateemployee_dev_level\":\"stateemployee_dev_level 1\",\"employee_gender\":\"employee_gender 1\",\"employee_hire_date\":\"2025 - 10 - 31T16: 35:45.426Z\",\"employee_onleave\":true,\"tech_stack\":[],\"project\":[]}";

            var response = WebHelper.Post(endpoint, request);

            Console.WriteLine(response);
        }

        [Test]
        public void GetRequest()
        {
            string endpoint = "https://6143a99bc5b553001717d06a.mockapi.io/testapi/v1//Users";

            var response = WebHelper.Get(endpoint);

            Console.WriteLine(response);
        }

    }
}