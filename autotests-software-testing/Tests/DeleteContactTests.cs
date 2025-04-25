using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : ContactTestBase
    {
        [Test]
        public void DeleteContact()
        {
            if (!app.Contacts.ContactExists())
            {
                app.Contacts.Create(new ContactData("TestName", "TestLastName")
                {
                    NickName = "test",
                    Title = "TestName TestLastName",
                    Company = "test",
                    Address = "test",
                    HomePhone = "123-123",
                    MobilePhone = "32323232",
                    WorkPhone = "333-333",
                    Email2 = "test2@jw.com",
                    HomePage = "testHomePage",
                    Bday = "18",
                    Bmonth = "June",
                    Byear = "1985",
                    Aday = "18",
                    Amonth = "June",
                    Ayear = "1985",
                });
            }
                        
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            
            app.Contacts.Delete(toBeRemoved);

            Assert.That(oldContacts.Count - 1, Is.EqualTo(app.Contacts.GetContactCount()));

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            Assert.That(oldContacts, Is.EqualTo(newContacts));
        }

        
    }
}
