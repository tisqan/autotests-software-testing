using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class CreationGroupTests : AuthTestBase
    {
       
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = GenerateRandomString(30),
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateGroup(GroupData group)
        {

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.That(oldGroups.Count + 1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(oldGroups, Is.EqualTo(newGroups));

        }

        [Test]
        public void CreateBadGroup()
        {

            GroupData group = new GroupData("nm'dsd");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.That(oldGroups.Count + 1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(oldGroups, Is.EqualTo(newGroups));
        }


    }
}
