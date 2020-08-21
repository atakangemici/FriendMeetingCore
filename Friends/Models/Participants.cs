using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Friends.Models
{
    public class Participants
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("reply")]
        public string Reply { get; set; }

        [Column("participant_name")]
        public string ParticipantName { get; set; }

    }
}
