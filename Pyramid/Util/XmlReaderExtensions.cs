using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Pyramid.Util
{
    public static class XmlReaderExtensions
    {
        public static T ReadDataFromFile<T>(string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (XmlReader reader = XmlReader.Create(filename))
            {
                return (T) ser.Deserialize(reader);
            }
        }
    }
}
