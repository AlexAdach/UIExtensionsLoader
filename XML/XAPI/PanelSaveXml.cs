using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UIExtensionsLoader.XML.XAPI.PanelSave
{
    internal class PanelSaveXml
    {


        public static Command GetCommand(string id, string body)
        {
            return new Command
            {
                UserInterface = new UserInterface
                {
                    Extensions = new Extensions
                    {
                        Panel = new Panel
                        {
                            Save = new Save
                            {
                                PanelId = id,
                                Body = body
                            }
                        }
                    }
                }
            };
        }

        [XmlRoot(ElementName = "Save")]
        public class Save
        {

            [XmlElement(ElementName = "PanelId")]
            public string PanelId { get; set; }

            [XmlElement(ElementName = "body")]
            public string Body { get; set; }
        }

        [XmlRoot(ElementName = "Panel")]
        public class Panel
        {

            [XmlElement(ElementName = "Save")]
            public Save Save { get; set; }
        }

        [XmlRoot(ElementName = "Extensions")]
        public class Extensions
        {

            [XmlElement(ElementName = "Panel")]
            public Panel Panel { get; set; }
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
