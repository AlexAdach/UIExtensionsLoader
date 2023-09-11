using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UIExtensionsLoader.Rest;
using UIExtensionsLoader.XML.XAPI.PanelSave;
using UIExtensionsLoader.XML.XAPI.ExtensionsList;
using UIExtensionsLoader.XML.XAPI.ExtensionsListResult;
using UIExtensionsLoader.XML.XAPI.PanelRemove;

namespace UIExtensionsLoader.Handlers
{
    public class ExtensionsHandler
    {

        private CiscoRest _client;
        private ExtensionsListResultXml.Command _loadedExtensions;

        public ExtensionsHandler(CiscoRest client)
        {
            _client = client;
        }

        public bool GetUIExtensionsList()
        {
            bool success = false;
            var response = _client.PostAsync(ExtensionsListXml.GetCommand);
            response.Wait();

            if (response == null)
                return success;


            if (response.Result.IsSuccessStatusCode)
            {

                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ExtensionsListResultXml.Command));

                    // Create a StringReader to read the XML data
                    using (StringReader stringReader = new StringReader(response.Result.Content))
                    {
                        // Deserialize the XML into an instance of your class
                        _loadedExtensions = (ExtensionsListResultXml.Command)serializer.Deserialize(stringReader);

                        SimplDebug.Success($"Total Current panels loaded {_loadedExtensions.ExtensionsListResult.Extensions.Panel.Count}");
                    }

                    success = true;
                }
                catch (Exception ex)
                {
                    SimplDebug.Error($"Error trying to deserialize response. {ex.Message}");
                }

            }


            return success;
        }

        public bool RemoveLoadedCustomControls(string controlPrefix)
        {
            bool success = false;

            try
            {
                foreach (var panel in _loadedExtensions.ExtensionsListResult.Extensions.Panel)
                {
                    if (panel.PanelId.StartsWith(controlPrefix))
                    {
                        var response = _client.PostAsync(PanelRemoveXml.GetCommand(panel.PanelId));
                        response.Wait();
                        if (response.Result.IsSuccessStatusCode)
                        {
                            SimplDebug.Success($"Removed Panel {panel.PanelId}");
                        }
                    }
                }
                success = true;

            }
            catch (Exception ex)
            {
                SimplDebug.Error($"Error deleting unused panels {ex.Message}");
            }


            return success;

        }

        public bool LoadRoomPanel(string id, string paneldata)
        {
            bool success = false;
            var response = _client.PostAsync(PanelSaveXml.GetCommand(id, paneldata));
            response.Wait();

            if (response.Result.IsSuccessStatusCode)
            {
                success = true;
            }

            return success;
        }
    }
}
