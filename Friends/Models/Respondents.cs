using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Friends.Models
{
    public class Respondents
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("respondent_name")]
        public string RespondentName { get; set; }

        [Column("reply_date")]
        public string ReplyDate { get; set; }



    }
}
