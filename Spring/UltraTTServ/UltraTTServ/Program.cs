using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UserService;
using GameService;
using GameService.GameSession;
using GameService.MatchMaker;

namespace UltraTTServ
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var host = new ServiceHost(typeof(UserService.UserService)))
            using (var gameSessionHost = new ServiceHost(typeof(GameSessionService)))
            using(var matchMakerHost = new ServiceHost(typeof(MatchMakerService)))
            {

                host.Open();
                gameSessionHost.Open();
                matchMakerHost.Open();

                Console.WriteLine("opened");

                Console.ReadLine();

                host.Close();
                gameSessionHost.Close();
                matchMakerHost.Close();
            }
        }
    }
}
