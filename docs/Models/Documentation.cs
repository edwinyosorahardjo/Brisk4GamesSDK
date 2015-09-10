using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace docs.Models
{
    public class Documentation
    {
        private XDocument xDoc;

        public Documentation(XDocument xDoc)
        {
            this.xDoc = xDoc;
            this.AssemblyName = xDoc.Descendants("assembly").First().Element("name").Value;
            this.Members = xDoc.Descendants("member").Select(m => Parse(m)).ToArray();
        }

        private DocumentationMember Parse(XElement member)
        {
            return new DocumentationMember(member);
        }

        public string AssemblyName { get; set; }
        public DocumentationMember[] Members { get; set; }
    }
}