using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ModifyContactTests : AuthTestBase
    {
        [Test]
        public void ModifyContact()
        {
            ContactData contact = new ContactData("Jhon555", "Wick666", "111@jw.com")
            {
                NickName = null,
                Title = null,
                Company = "JWCompany",
                Address = "Russia",
                HomePhone = "123-123",
                MobilePhone = "32323232",
                Work = null,
                Email2 = "222@jw.com",
                HomePage = "HomePage",
                Bday = "5",
                Bmonth = "July",
                Byear = "1999",
                Aday = "5",
                Amonth = "July",
                Ayear = "1985",
            };
            

            if (!app.Contacts.ContactExists())
            {
                app.Contacts.Create(new ContactData("TestName", "TestLastName", "test@jw.com")
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
            app.Contacts.Modify(contact, 2);
            
        }

        
    }
}
