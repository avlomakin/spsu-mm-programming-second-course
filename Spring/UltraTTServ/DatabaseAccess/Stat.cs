using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess
{
    public class Stat 
    {
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        [Key]
        public int UserId { get; set; }

        [DefaultValue(0)]
        public int Score { get; set; }

        [DefaultValue(0)]
        public int PlayedCross { get; set; }

        [DefaultValue(0)]
        public int WonCross { get; set; }

        [DefaultValue(0)]
        public int PlayedNought { get; set; }

        [DefaultValue(0)]
        public int WonNought { get; set; }
    }
}