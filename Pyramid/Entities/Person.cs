using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Pyramid.Entities
{
    public abstract class Person
    {
        [XmlAttribute("id")]
        public long Id { get; set; }
    }
}
