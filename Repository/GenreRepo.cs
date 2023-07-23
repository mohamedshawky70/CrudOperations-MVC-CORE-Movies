using Movies__CRUD_Operations_.Data;
using Movies__CRUD_Operations_.Models;

namespace Movies__CRUD_Operations_.Repository
{
    public class GenreRepo
    {
        private readonly ApplicationDbContext context;
        public GenreRepo(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<Genre> GetAll()
        {
            return (context.Genres.OrderBy(g=>g.Name).ToList());
        }
        public Genre GetById(int id)
        {
            return context.Genres.FirstOrDefault(g => g.Id == id);
        }
    }
}
