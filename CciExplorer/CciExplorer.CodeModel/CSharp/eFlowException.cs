using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TourreauGilles.CciExplorer.CodeModel.CSharp
{
    [XmlRoot("exception")]
    [DataContract(Name = "exception", Namespace = "")]
    public class eFlowException
    {
        public eFlowException(Type ExceptionFinally)
        {
            this.BaseName = ExceptionFinally.ToString();
            this.Name = ExceptionFinally.Name;
        }

        public eFlowException()
        {
            // TODO: Complete member initialization
        }

        [XmlElement("name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [XmlElement("basename")]
        [DataMember(Name = "baseName")]
        public string BaseName { get; set; }
    }
}
