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
            GroupData oldData = oldGroups[0];

            GroupData newData = new GroupData("testNamegroup1");
            newData.Header = "testHeadergroup1";
            newData.Footer = "testFootergroup1";

            app.Groups.Modify(newData, 0);

            Assert.That(oldGroups.Count, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(oldGroups, Is.EqualTo(newGroups));

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.That(newData.Name, Is.EqualTo(group.Name));
                }
                
            }
        }

    }
}
