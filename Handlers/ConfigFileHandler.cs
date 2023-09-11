using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UIExtensionsLoader.XML.Config;

namespace UIExtensionsLoader.Handlers
{
    public class ConfigFileHandler
    {

        public ConfigFileXML.Panel FoundPanel;
        public ConfigFileXML.Root ConfigFile;

        public ConfigFileXML.Root PanelToSend
        {
            get
            {
                return new ConfigFileXML.Root
                {
                    Panel = new List<ConfigFileXML.Panel> { FoundPanel }
                };
            }
        }

        public ConfigFileHandler()
        {


        }

        public bool GetControlFile(string filepath)
        {
            bool success = false;

            var rootDirectory = Crestron.SimplSharp.CrestronIO.Directory.GetApplicationRootDirectory();
            filepath = rootDirectory + filepath;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filepath);

                XmlSerializer serializer = new XmlSerializer(typeof(ConfigFileXML.Root));

                using (StringReader reader = new StringReader(xmlDoc.OuterXml))
                {
                    ConfigFile = (ConfigFileXML.Root)serializer.Deserialize(reader);
                }
                SimplDebug.Success("Config file loaded.");
                success = true;
            }
            catch (Exception ex)
            {
                SimplDebug.Error(ex.Message);
                throw;
            }


            return success;
        }

        public bool FindTargetPanel(string targetPanelId)
        {
            bool success = false;

            FoundPanel = ConfigFile.Panel.FirstOrDefault(panel => panel.PanelId == targetPanelId);

            if (FoundPanel == null)
            {
                SimplDebug.Error($"Could not find target panel {targetPanelId} in config file.");
            }
            else
            {
                SimplDebug.Success($"Found target panel {targetPanelId} in config file.");
                success = true;
            }

            return success;
        }

        public string GetPanelString()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigFileXML.Root));
            StringWriter stringWriter = new StringWriter();

            // Create an XmlWriter with settings to exclude the XML declaration
            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true, // Optional: to format the XML nicely
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                // Serialize the object to XML using the custom XmlWriter
                serializer.Serialize(xmlWriter, PanelToSend);
            }

            return stringWriter.ToString();

        }



    }
}
