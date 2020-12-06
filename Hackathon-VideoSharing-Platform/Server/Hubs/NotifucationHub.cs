using Hackathon_VideoSharing_Platform.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Hackathon_VideoSharing_Platform.Server.Hubs
{
    public class NotifucationHub : Hub
    {
        public async Task BroadcastNewVideoInfo(VideoMetaData videoMetaData)
        {
            await Clients.All.SendAsync("OnBroadcastNewVideoInfo", videoMetaData);
<<<<<<< HEAD
=======
            Debug.WriteLine("Send video: VideoMetaData:  \nTitle:{0}, \nPrice{1}, \n Address:{2}", videoMetaData.Title, videoMetaData.Price, videoMetaData.AddressAuthor);
>>>>>>> 1b4906da643d2fc2170db629828a647f6c7ca60a
        }
    }
}
