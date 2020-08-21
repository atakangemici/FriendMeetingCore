using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Friends.Models
{
  public class Questions
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("question")]
    public string Question { get; set; }

    [Column("question_type")]
    public string QuestionType { get; set; }
  }
}
