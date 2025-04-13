using System.Xml.Serialization;
using System.Text.Json;
using WebAddressbookTests;
using System.Text.Json.Serialization;
using System.Xml;


namespace addressbook_test_data_generators;

internal class Program
{
    static void Main(string[] args)
    {
        string dataType = args[0];
        int count = Convert.ToInt32(args[1]);
        string fileName = args[2];
        string format = args[3];
        StreamWriter writer = new StreamWriter(fileName);

        List<GroupData> groups = new List<GroupData>();
        List<ContactData> contacts = new List<ContactData>();
        
        if(dataType == "group")
        {
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = TestBase.GenerateRandomString(10),
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            if (format == "csv")
            {
                WriteGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteGroupsToJsonFile(groups, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format" + format);
            }

            writer.Close();
        }
        if(dataType == "contact")
        {
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Name = TestBase.GenerateRandomString(20),
                    LastName = TestBase.GenerateRandomString(20),
                    NickName = TestBase.GenerateRandomString(20),
                    Title = TestBase.GenerateRandomString(20),
                    Company = TestBase.GenerateRandomString(20),
                    Address = TestBase.GenerateRandomString(20),
                    HomePhone = TestBase.GenerateRandomString(20),
                    MobilePhone = TestBase.GenerateRandomString(20),
                    WorkPhone = TestBase.GenerateRandomString(20),
                    Email1 = TestBase.GenerateRandomString(20),
                    Email2 = TestBase.GenerateRandomString(20),
                    Email3 = TestBase.GenerateRandomString(20),
                    HomePage = TestBase.GenerateRandomString(20)
                });
            }
            if (format == "csv")
            {
                WriteContactToCsvFile(contacts, writer);
            }
            else if (format == "xml")
            {
                WriteContactToXmlFile(contacts, writer);
            }
            else if (format == "json")
            {
                WriteContactToJsonFile(contacts, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format" + format);
            }

            writer.Close();

        }
                   
    }

    static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
    {
        foreach (GroupData group in groups)
        {
            writer.WriteLine(String.Format("${0},${1},${2}",
                group.Name, group.Header, group.Footer));
        }
    }
    static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
    {
        new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
    }

    static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        writer.Write(JsonSerializer.Serialize(groups, options));
        
    }
    static void WriteContactToCsvFile(List<ContactData> contacts, StreamWriter writer)
    {
        foreach (ContactData contact in contacts)
        {
            writer.WriteLine(String.Format("${0},${1},${2},${3},${4}",
                contact.Name, contact.LastName, contact.NickName, contact.MobilePhone, contact.Email1));
        }
    }

    static void WriteContactToXmlFile(List<ContactData> contacts, StreamWriter writer)
    {
        new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
    }

    static void WriteContactToJsonFile(List<ContactData> contacts, StreamWriter writer)
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        writer.Write(JsonSerializer.Serialize(contacts, options));

    }



}
