using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExternalServices.MatchMaker;

namespace UltraTT.Game.Model
{
    class OnlineLobbyPageModel : IMatchMakerServiceCallback
    {
        private MatchMakerServiceClient _client;
        public event EventHandler<string> MatchFoundEvent; 

        public OnlineLobbyPageModel()
        {
            _client = new MatchMakerServiceClient(new InstanceContext(this), "NetTcpBinding_IMatchMakerService");
            _client.Open();
        }
        public void MatchFound(string opponentUsername)
        {
            MatchFoundEvent?.Invoke(this, opponentUsername);
        }

        public void Enqueue(string username)
        {
            _client.EnqueueAsync(username);
        }

        public void Dequeue(string username)
        {
            _client.DequeueAsync(username);
        }

        ~OnlineLobbyPageModel()
        {
            _client?.Close();
        }
    }
}
