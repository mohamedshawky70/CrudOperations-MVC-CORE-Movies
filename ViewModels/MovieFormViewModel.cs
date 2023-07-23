using Movies__CRUD_Operations_.Models;
using System.ComponentModel.DataAnnotations;

namespace Movies__CRUD_Operations_.ViewModels
{
    public class MovieFormViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Title { get; set; }
        public int Year { get; set; }
        [Range(1,10)]
        public double Rate { get; set; }
        [Required, StringLength(2500)]
        public string storeline { get; set; }
        [Required]
        public byte[] Poster { get; set; }
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }
        public List<Genre>Genres { get; set; }
    }
}
