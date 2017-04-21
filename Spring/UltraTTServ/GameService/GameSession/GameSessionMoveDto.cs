using System.Runtime.Serialization;

namespace GameService.GameSession
{
    [DataContract]
    public class GameSessionMoveDto
    {
        [DataMember]
        public int BigCell { get; set; }

        [DataMember]
        public int Position { get; set; }

        [DataMember]
        public bool IsCross { get; set; }
    }
}