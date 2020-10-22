using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace BasementHoofersQuiz.Models
{
    public class QuizModel
    {
        [Key]
        public int quizId { get; set; }
        [Display(Name = "Title")]
        public string quizTitle { get; set; }
        [Display(Name = "Description")]
        public string quizDescription { get; set; }

        public virtual AttemptModel Attempt { get; set; }
    }
}
