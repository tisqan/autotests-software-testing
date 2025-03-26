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
            if (!app.Groups.GroupExists())
            {
                app.Groups.Create(new GroupData("nameGroup")
                {
                    Header = "headerGroup",
                    Footer = "footerGroup"
                });
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData group = new GroupData("testNamegroup1");
            group.Header = "testHeadergroup1";
            group.Footer = "testFootergroup1";

            app.Groups.Modify(group, 0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(oldGroups, Is.EqualTo(newGroups));
        }

    }
}
