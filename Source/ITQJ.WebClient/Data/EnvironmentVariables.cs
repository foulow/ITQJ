using System.Diagnostics;

namespace ITQJ.WebClient.Data
{
    public static class EnvironmentVariables
    {
        // development
        // local chat hub needs to be running
        private const string ChatApiUrl = "https://localhost:44348/chatHub";
        //private const string ChatApiUrl = "https://audio2textrecorder.azurewebsites.net/chatHub";

        // production
        private const string ProductionChatApiUrl = "https://audio2textrecorder.azurewebsites.net/chatHub";

        // public keys
        public static string ChatHubUrl => Debugger.IsAttached ? ChatApiUrl : ProductionChatApiUrl;
    }
}
