using System.ServiceModel;

namespace GameService.MatchMaker
{

    [ServiceContract(CallbackContract = typeof(IMatchMakerServiceCallback))]
    public interface IMatchMakerService
    {
        [OperationContract(IsOneWay = true)]
        void Enqueue(string username);

        [OperationContract(IsOneWay = true)]
        void Dequeue(string username);
    }
}
