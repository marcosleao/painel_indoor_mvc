using Microsoft.AspNetCore.SignalR;

namespace PainelIndoorWeb.Extensions
{
    public class HubSignalR : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task ReloadPage()
        {
            await Clients.All.SendAsync("Reload");
        }

        public async Task PlayYouTubeVideo()
        {
            await Clients.All.SendAsync("Play");
        }

        public async Task StopYouTubeVideo()
        {
            await Clients.All.SendAsync("Stop");
        }
    }
}
