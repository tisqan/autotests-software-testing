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
        }

        
    }
}
