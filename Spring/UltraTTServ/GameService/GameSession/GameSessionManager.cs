using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;

namespace GameService.GameSession
{
    public class GameSessionManager
    {
        private static Dictionary<string, GameSessionService> _sessionsList = 
            new Dictionary<string, GameSessionService>();

        public static void RegNewSession(string username, GameSessionService service)
        {
            lock (_sessionsList)
            {
                _sessionsList.TryGetValue(username, out GameSessionService check);
                if (check != null)
                {
                    throw new FaultException(new FaultReason("Session already exists"));
                }
                _sessionsList.Add(username, service);
            }
        }

        public static GameSessionService GetGameSesionService(string username)
        {
            for (int i = 0; i < 30; i++)
            {
                GameSessionService result;
                lock (_sessionsList)
                {
                    _sessionsList.TryGetValue(username, out result);

                    if (result != null)
                    {
                        _sessionsList.Remove(username);
                        return result;
                    }
                    Thread.Sleep(200);
                }
            }
            throw new FaultException(new FaultReason("Can't find opponent"));
        }
    }
}