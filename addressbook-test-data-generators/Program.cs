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
        int count = Convert.ToInt32(args[0]);
        string fileName = args[1];
        string format = args[2];

        List<GroupData> groups = new List<GroupData>();
        for (int i = 0; i < count; i++)
        {
            groups.Add(new GroupData()
            {
                Name = TestBase.GenerateRandomString(10),
                Header = TestBase.GenerateRandomString(10),
                Footer = TestBase.GenerateRandomString(10)
            });
        }
        if (format == "excel")
        {
            WriteGroupsToExcelFile(groups, fileName);
        }
        else
        {
            StreamWriter writer = new StreamWriter(fileName);
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
        
    }

    static void WriteGroupsToExcelFile(List<GroupData> groups, string fileName)
    {
        
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

}
