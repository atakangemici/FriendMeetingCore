using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Friends.Models
{
    public class Replys
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("respondent_id")]
        public int RespondentId { get; set; }

        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("reply")]
        public string Reply { get; set; }

        [Column("question")]
        public string Question { get; set; }

        [Column("subject")]
        public string Subject { get; set; }

        [Column("respondent_name")]
        public string RespondentName { get; set; }


    }
}
