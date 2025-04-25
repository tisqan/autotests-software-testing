using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using System.Xml.Serialization;
using System.Text.Json;


namespace WebAddressbookTests
{

    [TestFixture]
    public class CreationGroupTests : GroupTestBase
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach(string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData()
                {
                    Name = parts[0],
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
            
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonSerializer.Deserialize<List<GroupData>>(
                File.ReadAllText(@"groups.json"));

        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void CreateGroup(GroupData group)
        {

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.That(oldGroups.Count + 1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = GroupData.GetAll();
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

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.That(oldGroups.Count + 1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(oldGroups, Is.EqualTo(newGroups));
        }

        [Test]
        public void TestDBConnectivity()
        {
            foreach (var contact in GroupData.GetAll()[0].GetContacts())
            {
                Console.Out.WriteLine(contact);
            }
        }

    }
}
