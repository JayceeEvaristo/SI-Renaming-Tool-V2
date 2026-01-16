using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SI_Renaming_Tool_V2.Controller
{
    public class DBConfig
    {
        public static string GetConnectionString()
        {
            string xmlPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "config.xml"
            );

            if (!File.Exists(xmlPath))
                throw new FileNotFoundException($"Config file not found: {xmlPath}");

            var doc = XDocument.Load(xmlPath);
            var group = doc.Element("Group")
                ?? throw new Exception("Missing <Group> element in config.xml");

            string host = GetValue(group, "Datasource");
            string port = GetValue(group, "Port");
            string serviceName = GetValue(group, "ServiceName");
            string userId = GetValue(group, "UserId");
            string password = GetValue(group, "Password");

            string connectionString =
            $@"User Id={userId};
            Password={password};
            Data Source=(DESCRIPTION=
                (ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port}))
                (CONNECT_DATA=(SERVICE_NAME={serviceName}))
            );";

            return connectionString;
        }

        private static string GetValue(XElement group, string name)
        {
            var value = group.Elements("String")
                             .FirstOrDefault(e => e.Attribute("Name")?.Value == name)
                             ?.Value;

            if (string.IsNullOrWhiteSpace(value))
                throw new Exception($"Missing or empty value for '{name}' in config.xml");

            return value.Trim();
        }
    }
}
