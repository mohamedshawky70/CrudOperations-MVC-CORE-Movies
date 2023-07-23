using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies__CRUD_Operations_.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required,MaxLength(250)]
        public string Title{ get; set; }
        [Display(Name = "Date of publication")]
        public DateTime Year{ get; set; }
        [Range(1,10)]
        public double Rate{ get; set; }
        [Required,MaxLength(2500)]
        public string storeline{ get; set; }
        [Required]
        [Display(Name ="Select poster...")]
        public string Poster{ get; set; }
        
        [Display(Name ="Genre")]
        public byte GenreId{ get; set; }
      


    }
}
