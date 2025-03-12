using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class DeleteGroupTests : TestBase
    {
        [Test]
        public void DeleteGroup()
        {
            app.Groups.Delete(1);

        }

    }
}
