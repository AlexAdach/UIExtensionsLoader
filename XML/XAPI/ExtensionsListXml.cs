using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UIExtensionsLoader.XML.XAPI.ExtensionsList
{
    internal class ExtensionsListXml
    {
        public static Command GetCommand
        {
            get
            {
                return new Command
                {
                    UserInterface = new UserInterface
                    {
                        Extensions = new Extensions
                        {
                            List = new object()
                        }
                    }
                };
            }
        }


        [XmlRoot(ElementName = "Extensions")]
        public class Extensions
        {

            [XmlElement(ElementName = "List")]
            public object List { get; set; }
        }

        [XmlRoot(ElementName = "UserInterface")]
        public class UserInterface
        {

            [XmlElement(ElementName = "Extensions")]
            public Extensions Extensions { get; set; }
        }

        [XmlRoot(ElementName = "Command")]
        public class Command
        {

            [XmlElement(ElementName = "UserInterface")]
            public UserInterface UserInterface { get; set; }
        }

    }
}
    namespace UIExtensionsLoader.XML.XAPI.ExtensionsListResult
    {
        internal class ExtensionsListResultXml
        {

            [XmlRoot(ElementName = "Widget")]
            public class Widget
            {

                [XmlElement(ElementName = "WidgetId")]
                public string WidgetId { get; set; }

                [XmlElement(ElementName = "Type")]
                public string Type { get; set; }

                [XmlElement(ElementName = "Name")]
                public string Name { get; set; }

                [XmlElement(ElementName = "Options")]
                public string Options { get; set; }

                [XmlAttribute(AttributeName = "item")]
                public int Item { get; set; }

                [XmlAttribute(AttributeName = "maxOccurrence")]
                public string MaxOccurrence { get; set; }

                [XmlText]
                public string Text { get; set; }
            }

            [XmlRoot(ElementName = "Row")]
            public class Row
            {

                [XmlElement(ElementName = "Name")]
                public string Name { get; set; }

                [XmlElement(ElementName = "Widget")]
                public List<Widget> Widget { get; set; }

                [XmlAttribute(AttributeName = "item")]
                public int Item { get; set; }

                [XmlAttribute(AttributeName = "maxOccurrence")]
                public string MaxOccurrence { get; set; }

                [XmlText]
                public string Text { get; set; }
            }

            [XmlRoot(ElementName = "Page")]
            public class Page
            {

                [XmlElement(ElementName = "PageId")]
                public string PageId { get; set; }

                [XmlElement(ElementName = "Name")]
                public string Name { get; set; }

                [XmlElement(ElementName = "Row")]
                public List<Row> Row { get; set; }

                [XmlElement(ElementName = "Options")]
                public string Options { get; set; }

                [XmlAttribute(AttributeName = "item")]
                public int Item { get; set; }

                [XmlAttribute(AttributeName = "maxOccurrence")]
                public string MaxOccurrence { get; set; }

                [XmlText]
                public string Text { get; set; }
            }

            [XmlRoot(ElementName = "Panel")]
            public class Panel
            {

                [XmlElement(ElementName = "Icon")]
                public string Icon { get; set; }

                [XmlElement(ElementName = "Location")]
                public string Location { get; set; }

                [XmlElement(ElementName = "ActivityType")]
                public string ActivityType { get; set; }

                [XmlElement(ElementName = "Name")]
                public string Name { get; set; }

                [XmlElement(ElementName = "PanelId")]
                public string PanelId { get; set; }

                [XmlElement(ElementName = "Origin")]
                public string Origin { get; set; }

                [XmlElement(ElementName = "Order")]
                public int Order { get; set; }

                [XmlElement(ElementName = "Color")]
                public string Color { get; set; }

                [XmlElement(ElementName = "Visibility")]
                public string Visibility { get; set; }

                [XmlElement(ElementName = "Page")]
                public List<Page> Page { get; set; }

                [XmlAttribute(AttributeName = "item")]
                public int Item { get; set; }

                [XmlAttribute(AttributeName = "maxOccurrence")]
                public string MaxOccurrence { get; set; }

                [XmlText]
                public string Text { get; set; }
            }

            [XmlRoot(ElementName = "Extensions")]
            public class ExtensionsResult
            {

                [XmlIgnore]
                public DateTime Version { get; set; }

                [XmlElement(ElementName = "Panel")]
                public List<Panel> Panel { get; set; }
            }

            [XmlRoot(ElementName = "ExtensionsListResult")]
            public class ExtensionsListResult
            {

                [XmlElement(ElementName = "Extensions")]
                public ExtensionsResult Extensions { get; set; }

                [XmlAttribute(AttributeName = "status")]
                public string Status { get; set; }

                [XmlText]
                public string Text { get; set; }
            }

            [XmlRoot(ElementName = "Command")]
            public class Command
            {

                [XmlElement(ElementName = "ExtensionsListResult")]
                public ExtensionsListResult ExtensionsListResult { get; set; }
            }

        }
    }

