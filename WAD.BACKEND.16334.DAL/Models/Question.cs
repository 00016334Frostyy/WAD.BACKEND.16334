using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._16334.Models
{
    public class Question
    {
        [Key]
        public int id { get; set; } 

        [Required(ErrorMessage = "Question text is required.")]
        [MaxLength(500, ErrorMessage = "Question cannot exceed 500 characters.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "SurveyId is required.")]
        public int SurveyId { get; set; }  

        [ForeignKey("SurveyId")]
        public Survey? Survey { get; set; }
    }
}
