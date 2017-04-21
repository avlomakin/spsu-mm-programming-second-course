using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GameService.MatchMaker
{

    [ServiceContract]
    public interface IMatchMakerServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MatchFound(string opponentUsername);
    }
}
