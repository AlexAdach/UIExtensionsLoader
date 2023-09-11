using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UIExtensionsLoader.XML.XAPI.PanelRemove
{
    public class PanelRemoveXml
    {
        public static Command GetCommand(string panelID)
        {
            return new Command
            {
                UserInterface = new UserInterface
                {
                    Extensions = new Extensions
                    {
                        Panel = new Panel
                        {
                            Remove = new Remove
                            {
                                PanelId = panelID
                            }
                        }
                    }
                }
            };
        }



        [XmlRoot(ElementName = "Remove")]
        public class Remove
        {

            [XmlElement(ElementName = "PanelId")]
            public string PanelId { get; set; }

        }

        [XmlRoot(ElementName = "Panel")]
        public class Panel
        {

            [XmlElement(ElementName = "Remove")]
            public Remove Remove { get; set; }
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
