using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeleteContactToGroupTests : AuthTestBase
    {

        [Test]
        public void TestDeleteContactToGroup()
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

            List<ContactData> contact = ContactData.GetAll();
            if (app.Contacts.ContactExistsInDB(contact))
            {
                app.Contacts.Create(new ContactData()
                {
                    Name = "TestName",
                    LastName = "TestLastName",
                    NickName = "test",

                });
            }


            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (app.Contacts.ContactExistsInGroupInDB(oldList, group))
            {
                app.Contacts.AddContactToGroup(contact.First(), group);
            }

            app.Contacts.DeleteContactFromGroup(contact.First(), group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact.First());
            oldList.Sort();
            newList.Sort();

            Assert.That(oldList, Is.EqualTo(newList));
        }

    }
}
