using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace BasementHoofersQuiz.Models
{
    public class AttemptModel 
    {
        [Key]
        public int attemptId { get; set; }
        [Display(Name = "Quiz Title:")]
        public int quizId { get; set; }
        [Display(Name = "User:")]
        public string UserId { get; set; }
        [Display(Name = "Your Result:")]
        public string quizResult { get; set; }
        [Display(Name = "Date:")]
        public string attemptDateTime { get; set; }

        public virtual ICollection<QuizModel> Quiz { get; set; }
    }
}
