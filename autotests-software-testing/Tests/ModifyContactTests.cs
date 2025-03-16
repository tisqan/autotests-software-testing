using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ModifyContactTests : TestBase
    {
        [Test]
        public void ModifyContact()
        {
            ContactData contact = new ContactData("Jhon555", "Wick666", "111@jw.com");
            contact.NickName = null;
            contact.Title = null;
            contact.Company = "JWCompany";
            contact.Address = "Russia";
            contact.HomePhone = "123-123";
            contact.MobilePhone = "32323232";
            contact.Work = null;
            contact.Email2 = "222@jw.com";
            contact.HomePage = "HomePage";
            contact.Bday = "5";
            contact.Bmonth = "July";
            contact.Byear = "1999";
            
            app.Contacts.Modify(contact, 3);
            
        }

        
    }
}
