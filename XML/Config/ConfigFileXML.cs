using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UIExtensionsLoader.XML.Config
{
    internal class ConfigFileXML
    {
        [XmlRoot(ElementName = "Panel")]
        public class Panel
        {
            [XmlElement(ElementName = "Order")]
            public int Order { get; set; }

            [XmlElement(ElementName = "PanelId")]
            public string PanelId { get; set; }

            [XmlElement(ElementName = "Origin")]
            public string Origin { get; set; }

            [XmlElement(ElementName = "Location")]
            public string Location { get; set; }

            [XmlElement(ElementName = "Icon")]
            public string Icon { get; set; }

            [XmlElement(ElementName = "Color")]
            public string Color { get; set; }

            [XmlElement(ElementName = "Name")]
            public string Name { get; set; }

            [XmlElement(ElementName = "ActivityType")]
            public string ActivityType { get; set; }

            [XmlElement(ElementName = "Page")]
            public List<Page> Page { get; set; }
        }

        [XmlRoot(ElementName = "Widget")]
        public class Widget
        {

            [XmlElement(ElementName = "WidgetId")]
            public string WidgetId { get; set; }

            [XmlElement(ElementName = "Name")]
            public string Name { get; set; }

            [XmlElement(ElementName = "Type")]
            public string Type { get; set; }

            [XmlElement(ElementName = "Options")]
            public string Options { get; set; }
        }

        [XmlRoot(ElementName = "Row")]
        public class Row
        {

            [XmlElement(ElementName = "Name")]
            public string Name { get; set; }

            [XmlElement(ElementName = "Widget")]
            public List<Widget> Widget { get; set; }
        }

        [XmlRoot(ElementName = "Page")]
        public class Page
        {

            [XmlElement(ElementName = "Name")]
            public string Name { get; set; }

            [XmlElement(ElementName = "Row")]
            public List<Row> Row { get; set; }

            [XmlElement(ElementName = "PageId")]
            public string PageId { get; set; }

            [XmlElement(ElementName = "Options")]
            public string Options { get; set; }
        }

        [XmlRoot(ElementName = "Extensions")]
        public class Root
        {

            //[XmlElement(ElementName = "Version")]
            [XmlIgnore]
            public DateTime Version { get; set; }

            [XmlElement(ElementName = "Panel")]
            public List<Panel> Panel { get; set; }
        }




    }
}
