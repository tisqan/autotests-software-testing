using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class CreationGroupTests : TestBase
    {
        [Test]
        public void CreateGroup()
        {
            
            GroupData group = new GroupData("testNamegroup");
            group.Header = "testHeadergroup";
            group.Footer = "testFootergroup";

            app.Groups.Create(group);

        }

        [Test]
        public void CreateEmptyGroup()
        {
            
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);

        }


    }
}
