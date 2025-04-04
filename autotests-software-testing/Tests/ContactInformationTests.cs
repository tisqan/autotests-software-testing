using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.That(fromTable, Is.EqualTo(fromForm));
            Assert.That(fromTable.Address, Is.EqualTo(fromForm.Address));
            Assert.That(fromTable.AllPhones, Is.EqualTo(fromForm.AllPhones));
            Assert.That(fromTable.AllEmails, Is.EqualTo(fromForm.AllEmails));
        }

        [Test]
        public void TestContactInformationProperties()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromPageProperties = app.Contacts.GetContactInformationViewProperties(0);

            Assert.That(fromForm.FullName, Is.EqualTo(fromPageProperties.FullName));
            Assert.That(fromForm.NickName, Is.EqualTo(fromPageProperties.NickName));
            Assert.That(fromForm.Title, Is.EqualTo(fromPageProperties.Title));
            Assert.That(fromForm.Company, Is.EqualTo(fromPageProperties.Company));
            Assert.That(fromForm.Address, Is.EqualTo(fromPageProperties.Address));
            Assert.That(fromForm.HomePhone, Is.EqualTo(fromPageProperties.HomePhone));
            Assert.That(fromForm.MobilePhone, Is.EqualTo(fromPageProperties.MobilePhone));
            Assert.That(fromForm.WorkPhone, Is.EqualTo(fromPageProperties.WorkPhone));
        }


    }


}
