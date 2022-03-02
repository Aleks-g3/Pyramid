using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pyramid.Entities
{
    public class Uczestnik
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        public Uczestnik[] uczestnik { get; set; }
    }
}
