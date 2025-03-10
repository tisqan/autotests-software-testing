using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactTests : TestBase
    {
        [Test]
        public void CreateContact()
        {
            ContactData contact = new ContactData("Jhon", "Wick", "111@jw.com");
            contact.NickName = "JW5";
            contact.Title = "Jhon Wick";
            contact.Company = "JWCompany";
            contact.Address = "Russia";
            contact.HomePhone = "123-123";
            contact.MobilePhone = "32323232";
            contact.Work = "GeneralWorker";
            contact.Email2 = "222@jw.com";
            contact.HomePage = "HomePage";
            contact.Bday = "18";
            contact.Bmonth = "June";
            contact.Byear = "1985";
            
            app.Contacts.Create(contact);
            
        }

        
    }
}
