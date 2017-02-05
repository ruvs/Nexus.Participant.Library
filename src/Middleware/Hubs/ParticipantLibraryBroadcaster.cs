using System.Threading.Tasks;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Microsoft.AspNet.SignalR;

namespace Nexus.ParticipantLibrary.Middleware.Hubs
{
    public class ParticipantLibraryBroadcaster : Hub  //<IParticipantLibraryBroadcaster>
    {

        public void Subscribe(string customerId)
        {
            Groups.Add(Context.ConnectionId, customerId);
        }

        public void Unsubscribe(string customerId)
        {
            Groups.Remove(Context.ConnectionId, customerId);
        }


        public override Task OnConnected()
        {
            // Set connection id for just connected client only
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
        }

        // Server side methods called from client
        public Task Subscribe(int id)
        {
            return Groups.Add(Context.ConnectionId, id.ToString());
        }

        public Task Unsubscribe(int id)
        {
            return Groups.Remove(Context.ConnectionId, id.ToString());
        }

        public void SendMessageTest(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }

    // Client side methods to be invoked by Broadcaster Hub
    public interface IParticipantLibraryBroadcaster
    {
        Task SetConnectionId(string connectionId);
        Task UpdateParticipantLibraryItem(ParticipantLibraryItemDto pliDto);
        Task AddParticipantLibraryItem(ParticipantLibraryItemDto pliDto);
    }

    internal enum ParticipantLibraryBroadcasterEventsEnum
    {
        ClientsAll_GetDetailsByKey
    }
}