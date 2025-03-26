using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : AuthTestBase
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
                    Work = "test",
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
                        
            List<ContactData> oldContacts = app.Contacts.GetGroupList();

            app.Contacts.Delete(2);

            List<ContactData> newContacts = app.Contacts.GetGroupList();

            oldContacts.RemoveAt(0);
            Assert.That(oldContacts, Is.EqualTo(newContacts));
        }

        
    }
}
