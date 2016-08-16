using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TourreauGilles.CciExplorer.CodeModel.CSharp
{
    [XmlRoot("methodException")]
    public class eFlowMethodException
    {
        //[XmlElement("throwsIntoCatch")]
        //public eFlowThrowsIntoCatch ThrowsIntoCatch { get; set; }
        //[DataMember(Name = "exception")]
        //public eFlowException  ExceptionReference { get; set; }
        [XmlElement("kind")]
        public string Kind { get; set; }
        [XmlElement("isGeneric")]
        public bool IsGeneric { get; set; }
        [XmlElement("startOffSet")]
        public string StartOffSet { get; set; }
        [XmlElement("endOffSet")]
        public string EndOffSet { get; set; }
    }

    [XmlRoot("throwsIntoCatch")]
    public class eFlowThrowsIntoCatch
    {
        [XmlElement("string")]
        public string String { get; set; }
    }
}
