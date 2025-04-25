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
    public class ModifyGroupTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            GroupData newData = new GroupData("testNamegroup1");
            newData.Header = "testHeadergroup1";
            newData.Footer = "testFootergroup1";

            app.Groups.Modify(oldData.Id, newData);

            Assert.That(oldGroups.Count, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = GroupData.GetAll();
            oldData.Name = newData.Name;
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
