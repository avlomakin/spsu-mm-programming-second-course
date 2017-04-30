using System.Runtime.Serialization;

namespace UserService.Dto
{

    [DataContract]
    public class StatDto
    {

        [DataMember]
        public  int Score { get; set; }

        [DataMember]
        public double TotalWinrate { get; set; }

        [DataMember]
        public double CrossWinrate { get; set; }

        [DataMember]
        public double NoughtWinrate { get; set; }



    }
}
