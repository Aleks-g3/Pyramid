using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pyramid.Entities;

namespace Pyramid.Services
{
    public class OperationService :IOperationService
    {
        public List<Person> GetMembers()
        {
           ReadDataFromFile();

           return new List<Person>();
        }

        private void ReadDataFromFile()
        {
            string json = GetDataFromXmlAsJsonByFilename("Piramida.xml");

            //JObject jo = JObject.Parse(json);
            //json = jo["piramida"].ToString();

            try
            {
                var dto = JsonConvert.DeserializeObject<Piramida>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            

        }

        public string GetDataFromXmlAsJsonByFilename(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            return JsonConvert.SerializeXmlNode(doc);
        }

        public static object Deserialize(string json)
        {
            return ToObject(JToken.Parse(json));
        }

        private static object ToObject(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    return token.Children<JProperty>()
                        .ToDictionary(prop => prop.Name,
                            prop => ToObject(prop.Value));

                case JTokenType.Array:
                    return token.Select(ToObject).ToList();

                default:
                    return ((JValue)token).Value;
            }
        }
    }
}
