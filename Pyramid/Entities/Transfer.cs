using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pyramid.Entities
{
    [XmlRoot("przelew")]
    public class Transfer
    {
        
        [XmlAttribute("od")]
        public long MemberID { get; set; }
        [XmlAttribute("kwota")]
        public long Amount { get; set; }
    }
}
