using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groupList = GroupData.GetAll();

            if (app.Groups.GroupExistsInDB(groupList))
            {
                app.Groups.Create(new GroupData()
                {
                    Name = "nameGroup",
                    Header = "headerGroup",
                    Footer = "footerGroup"
                });
            }

            List<ContactData> contactList = ContactData.GetAll();
            if (app.Contacts.ContactExistsInDB(contactList))
            {
                app.Contacts.Create(new ContactData()
                {
                    Name = "TestName",
                    LastName = "TestLastName",
                    NickName = "test",

                });
            }



            GroupData group = GroupData.GetAll()[0];
            
            List<ContactData> allcontacts = group.GetContacts();
            List<ContactData> contacts = ContactData.GetAll();
            
            if (app.Contacts.ContactExistsInGroupInDB(allcontacts, group) == false)
            {
                app.Contacts.DeleteContactFromGroup(contacts.First(), group);
            }
            
            List<ContactData> oldList = group.GetContacts();
            
            ContactData contact = contacts.Except(oldList).First();
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.That(oldList, Is.EqualTo(newList));
        }


    }
}
