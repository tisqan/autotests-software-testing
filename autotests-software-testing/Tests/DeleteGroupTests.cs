using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class DeleteGroupTests : AuthTestBase
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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Delete(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            
            oldGroups.RemoveAt(0);
            Assert.That(oldGroups, Is.EqualTo(newGroups));


        }

    }
}
