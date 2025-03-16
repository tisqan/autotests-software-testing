using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class ModifyGroupTests : AuthTestBase
    {
        [Test]
        public void ModifyGroup()
        {
            GroupData group = new GroupData("testNamegroup1");
            group.Header = "testHeadergroup1";
            group.Footer = "testFootergroup1";

            app.Groups.Modify(group, 1);

        }

    }
}
