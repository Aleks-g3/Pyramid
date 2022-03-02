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
using Pyramid.Util;

namespace Pyramid.Services
{
    public class OperationService :IOperationService
    {
        public Member GetHierarchy()
        {
            return FetchHierarchy();
        }

        public Transfers GetTransfers()
        {
            var result = XmlReaderExtensions.ReadDataFromFile<Transfers>("Przelewy.xml");

            return result;
        }

        private Member FetchHierarchy()
        {
            var result = XmlReaderExtensions.ReadDataFromFile<PyramidEntity>("Piramida.xml");
            if (result != null)
            {
                SetParent(result.Member);
                return result.Member;
            }

            return null;
        }

        private void SetParent(Member member)
        {
            foreach (var tmpMember in member.Members)
            {
                tmpMember.Parent = member;
                if (tmpMember.Members != null)
                {
                    SetParent(tmpMember);
                }
            }
        }
    }
}
