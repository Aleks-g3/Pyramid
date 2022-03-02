using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pyramid.Entities
{
    [XmlRoot("piramida")]
    public class PyramidEntity
    {
        [XmlElement("uczestnik")]
        public Member Member { get; set; }
    }
}
