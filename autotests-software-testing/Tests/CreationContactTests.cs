using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Xml.Serialization;
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
        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> groups = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new ContactData()
                {
                    Name = parts[0],
                    LastName = parts[1],
                    NickName = parts[2],
                    MobilePhone = parts[3],
                    Email1 = parts[4]
                });
            }
            return groups;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contact = new List<ContactData>();
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contact.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonSerializer.Deserialize<List<ContactData>>(
                File.ReadAllText(@"contact.json"));

        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
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
