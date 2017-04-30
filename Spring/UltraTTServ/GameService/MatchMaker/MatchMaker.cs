using System;
using System.Collections.Generic;
using System.Linq;

namespace GameService.MatchMaker
{
    public class MatchMaker
    {
        private static volatile MatchMaker _instance;
        private static object locker = new object();

        private List<Player> _players; 

        private class Player : IEquatable<Player>
        {
            public Action<string> Notificator { get; }

            public string Username { get; }

            public Player(string name, Action<string> notificator)
            {
                Username = name;
                Notificator = notificator;
            }

            public bool Equals(Player other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(Username, other.Username);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Player) obj);
            }

            public override int GetHashCode()
            {
                return (Username != null ? Username.GetHashCode() : 0);
            }
        }

        private MatchMaker()
        {
            _players = new List<Player>();
        }

        public static MatchMaker GetInstance()
        {
            if (_instance != null) return _instance;
            lock (locker)
            {
                if(_instance == null)
                    _instance = new MatchMaker();
            }
            return _instance;
        }

        public void Enqueue(string username, Action<string> notificator)
        {
            lock (_players)
            {
                if (_players.Contains(new Player(username, null))) return;
                if (_players.Count > 0)
                {
                    var item = _players[0];
                    _players.RemoveAt(0);
                    notificator.BeginInvoke(item.Username, null, null);
                    item.Notificator.BeginInvoke(username, null, null);
                    Console.WriteLine($"Match found: {item.Username} {username}");
                }
                else
                {
                    _players.Add(new Player(username, notificator));
                }
            }
        }

        public void Dequeue(string username)
        {
            lock (_players)
            {
                _players.Remove(new Player(username, null));
            }
        }

    }
}