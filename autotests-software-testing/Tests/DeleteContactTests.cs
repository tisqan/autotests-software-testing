using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : TestBase
    {
        [Test]
        public void DeleteContact()
        {
            app.Contacts.Delete(5);
        }

        
    }
}
