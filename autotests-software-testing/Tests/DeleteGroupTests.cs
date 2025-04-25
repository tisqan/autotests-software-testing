using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class DeleteGroupTests : GroupTestBase
    {
        [Test]
        public void DeleteGroup()
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
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Delete(toBeRemoved);

            Assert.That(oldGroups.Count - 1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = GroupData.GetAll();

            
            oldGroups.RemoveAt(0);
            Assert.That(oldGroups, Is.EqualTo(newGroups));

            foreach(GroupData group in newGroups)
            {
                Assert.That(group.Id == toBeRemoved.Id, Is.False);
            }


        }

    }
}
