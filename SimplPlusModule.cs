
using Crestron.SimplSharp;
using UIExtensionsLoader.Handlers;
using UIExtensionsLoader.Rest;

namespace UIExtensionsLoader
{
    public class SimplPlusModule
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string FilePath { get; set; }
        public string TargetPanelId { get; set; }
        public string ControlPanelPrefix { get; set; }


        public SimplPlusModule() { }

        


        public ushort LoadConfigGo()
        {
            using (CiscoRest ciscoRest = new CiscoRest(Host, Username, Password))
            {

                ConfigFileHandler configHandler = new ConfigFileHandler();


                if (!configHandler.GetControlFile(FilePath))
                    return 0;

                if (!configHandler.FindTargetPanel(TargetPanelId))
                    return 0;


                ExtensionsHandler extensionsHandler = new ExtensionsHandler(ciscoRest);

                if (!extensionsHandler.GetUIExtensionsList())
                    return 0;

                if (!extensionsHandler.RemoveLoadedCustomControls(ControlPanelPrefix))
                    return 0;

                if (!extensionsHandler.LoadRoomPanel(TargetPanelId, configHandler.GetPanelString()))
                    return 0;
            }

            return 1;

        }

    }

    public delegate void SuccessDelegate(SimplSharpString message); 
    public delegate void ErrorDelegate(SimplSharpString message); 

    public static class SimplDebug
    {
        public static SuccessDelegate SuccessDelegateHandler { get; set; }
        public static ErrorDelegate ErrorDelegateHandler { get; set; }

        public static void Error(string message)
        {
            if (ErrorDelegateHandler != null)
            {
                ErrorDelegateHandler.Invoke(message);
            }
        }

        public static void Success(string message)
        {
            if (SuccessDelegateHandler != null)
            {
                SuccessDelegateHandler.Invoke(message);
            }
        }
    }
}
