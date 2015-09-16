using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace docs.Models
{
    public class DocumentationMember
    {
        private XElement member;

        public DocumentationMember(XElement member)
        {
            this.member = member;
            this.Name = member.Attribute("name").Value.Substring(2);
            this.Type = member.Attribute("name").Value.Substring(0, 1);
            this.Summary = member.Descendants("summary").First().Value;
            this.Parameters = Parse(member.Descendants("param"));
            if (member.Descendants("returns").Any())
            {
                this.Returns = ReadRaw(member.Descendants("returns").First());
            }
            else
            {
                this.Returns = "Undocumented return type";
            }
            if (member.Descendants("example").Any())
            {
                this.Example = member.Descendants("example").First().Value;
            }
            if (member.Descendants("seealso").Any())
            {
                this.SeeAlso = member.Descendants("seealso").First().Attribute("cref").Value;
            }
        }

        private string ReadRaw(XElement xElement)
        {
            var reader = xElement.CreateReader();
            reader.MoveToContent();
            return reader.ReadInnerXml();
        }

        private Dictionary<string, string> Parse(IEnumerable<XElement> parameterNodes)
        {
            if (!parameterNodes.Any())
            {
                return new Dictionary<string, string> { };
            }

            var parameters = new Dictionary<string, string>();
            foreach (var item in parameterNodes)
            {
                parameters.Add(item.Attribute("name").Value, item.Value);
            }
            return parameters;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public Dictionary<string,string> Parameters { get; set; }
        public string Returns { get; set; }
        public string Example { get; set; }
        public DocumentationMember[] Children { get; set; }
        public string SeeAlso { get; set; }
    }
}