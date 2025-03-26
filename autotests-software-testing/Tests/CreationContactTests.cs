using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreationContactTests : AuthTestBase
    {
        [Test]
        public void CreateContact()
        {
            ContactData contact = new ContactData("Jhon", "Wick")
            {
               NickName = "JW5",
               Title = "Jhon Wick",
               Company = "JWCompany",
               Address = "Russia",
               HomePhone = "123-123",
               MobilePhone = "32323232",
               Work = "GeneralWorker",
               Email2 = "222@jw.com",
               HomePage = "HomePage",
               Bday = "18",
               Bmonth = "June",
               Byear = "1985",
               Aday = "18",
               Amonth = "June",
               Ayear = "1985"
            };

            List<ContactData> oldContacts = app.Contacts.GetGroupList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetGroupList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.That(oldContacts, Is.EqualTo(newContacts));

            
            
        }

        
    }
}
