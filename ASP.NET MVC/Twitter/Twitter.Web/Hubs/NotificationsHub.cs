using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Twitter.Web.Hubs
{
    [HubName("notifications")]
    public class NotificationsHub : Hub
    {
        public void SendNotification(string type, string notification)
        {
            this.Clients.Others.receiveNotification(type, notification);
        }
    }
}