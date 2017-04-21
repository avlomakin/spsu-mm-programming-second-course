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
        private static Queue<Tuple<string, IMatchMakerServiceCallback>> _queue = new Queue<Tuple<string, IMatchMakerServiceCallback>>();
        private IMatchMakerServiceCallback _callback;

        public MatchMakerService()
        {
            _callback = OperationContext.Current.GetCallbackChannel<IMatchMakerServiceCallback>();
        }

        public void Enqueue(string username)
        {
            Console.WriteLine(username + " Enqueued");
            lock (_queue)
            {
                if (_queue.Count > 0)
                {
                    var item = _queue.Dequeue();
                    _callback.MatchFound(item.Item1);
                    item.Item2.MatchFound(username);
                    Console.WriteLine("Match found: " + item.Item1 + " " + username);
                }
                else
                {
                    _queue.Enqueue(new Tuple<string, IMatchMakerServiceCallback>(username, _callback));
                }
            }
        }

        public void Dequeue(string username)
        {
            Console.WriteLine(username + " Dequeued");
            lock (_queue)
            {
                if (_queue.Count > 0 &&_queue.Peek().Item1 == username)
                {
                    _queue.Dequeue();
                }
            }
        }
    }
}
