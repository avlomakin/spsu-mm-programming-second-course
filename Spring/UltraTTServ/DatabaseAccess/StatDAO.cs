using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseAccess
{
    public class StatDAO
    {
        public UttContext Context { private get; set; }

        public int GetScore(string username)
        {
            return Context.Stats.First(u => u.User.Username == username).Score;
        }

        public void CreatetStat(string username)
        {
            Context.Stats.Add(new Stat()
            {
                User = Context.Users.First(u => u.Username == username)
            });
            Context.SaveChanges();
        }

        public Stat GetStat(string username)
        {
            return Context.Stats.First(u => u.User.Username == username);
        }

        public List<Stat> GetTop()
        {
            return Context.Stats.OrderByDescending(s => s.Score).Take(100).ToList();
        }

        public void GamePlayed(string username, string side)
        {
            var stat = Context.Stats.First(s => s.User.Username == username);
            if (side.ToLower() == "cross")
            {
                stat.PlayedCross++;
            }
            else
            {
                stat.PlayedNought++;
            }
            Context.SaveChanges();
        }

        public void GameWon(string username, string side)
        {
            var stat = Context.Stats.First(s => s.User.Username == username);
            if (side.ToLower() == "cross")
            {
                stat.WonCross++;
                stat.Score += 5;
            }
            else
            {
                stat.WonNought++;
                stat.Score += 5;
            }
            Context.SaveChanges();
        }
    }
}
