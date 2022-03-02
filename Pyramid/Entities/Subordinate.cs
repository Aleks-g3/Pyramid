using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Pyramid.Entities
{
    [JsonArray("uczestnik")]
    public class Subordinate : Person
    {
        [JsonProperty("uczestnik")]
        public Supervisor Superior { get; set; }
    }
}
