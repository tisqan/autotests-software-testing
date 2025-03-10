using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class AddNewGroupTest : TestBase
    {
        [Test]
        public void CreateGroup()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("testNamegroup");
            group.Header = "testHeadergroup";
            group.Footer = "testFootergroup";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            
        }

        
    }
}
