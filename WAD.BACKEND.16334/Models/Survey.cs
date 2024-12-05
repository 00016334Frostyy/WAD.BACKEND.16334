using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._16334.Models
{
    public class Survey
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }
    }
}
