using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Pyramid.Entities
{
    [XmlRoot("uczestnik")]
    public class Member : Person
    {
        [XmlElement("uczestnik")]
        public Member[] Members { get; set; }
        [XmlIgnore]
        public Member Parent { get; set; }
    }
}
