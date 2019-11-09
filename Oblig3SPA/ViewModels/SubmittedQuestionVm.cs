using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig3SPA.ViewModels
{
    public class SubmittedQuestionVm
    {
        [Required]
        [StringLength(800)]
        [DataType(DataType.Text)]
        public string QuestionText { get; set; }
    }
}
