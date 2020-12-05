using Hackathon_VideoSharing_Platform.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Hackathon_VideoSharing_Platform.Server.Hubs
{
    public class NotifucationHub : Hub
    {
        async Task BroadcastNewVideoInfo(VideoMetaData videoMetaData)
        {
            await Clients.All.SendAsync("OnBroadcastNewVideoInfo", videoMetaData);
        }
    }
}
