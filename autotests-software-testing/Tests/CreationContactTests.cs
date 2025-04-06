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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData()
                {
                    Name = GenerateRandomString(20),
                    LastName = GenerateRandomString(20),
                    NickName = GenerateRandomString(20),
                    Title = GenerateRandomString(20),
                    Company = GenerateRandomString(20),
                    Address = GenerateRandomString(20),
                    HomePhone = GenerateRandomString(20),
                    MobilePhone = GenerateRandomString(20),
                    WorkPhone = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    HomePage = GenerateRandomString(20)

                });
            }
            return contact;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateContact(ContactData contact)
        {

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.That(oldContacts.Count + 1, Is.EqualTo(app.Contacts.GetContactCount()));

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.That(oldContacts, Is.EqualTo(newContacts));

            
            
        }

        
    }
}
