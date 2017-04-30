using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GameService.MatchMaker
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MatchMakerService : IMatchMakerService
    {
        private MatchMaker _matchMaker = MatchMaker.GetInstance();
        private IMatchMakerServiceCallback _callback;

        public MatchMakerService()
        {
            _callback = OperationContext.Current.GetCallbackChannel<IMatchMakerServiceCallback>();
        }

        public void Enqueue(string username)
        {
            Console.WriteLine(username + " Enqueued");
            _matchMaker.Enqueue(username, _callback.MatchFound);
        }

        public void Dequeue(string username)
        {
            Console.WriteLine(username + " Dequeued");
            _matchMaker.Dequeue(username);
        }
    }
}
