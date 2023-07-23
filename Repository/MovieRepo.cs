using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies__CRUD_Operations_.Data;
using Movies__CRUD_Operations_.Models;

namespace Movies__CRUD_Operations_.Repository
{
    public class MovieRepo
    {
        private readonly ApplicationDbContext context;
        public MovieRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public void Creat(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public List<Movie> GetAll()
        {
            return (context.Movies.OrderByDescending(m=>m.Rate).ToList());
        }
        public Movie GetById(int?id)
        {
            return (context.Movies.FirstOrDefault(m=>m.Id==id));
        }
        public void Update(Movie NewMovie)
        {
            int id = NewMovie.Id;
            Movie movie= context.Movies.FirstOrDefault(m=>m.Id== id);
            movie.Title = NewMovie.Title;
            movie.Rate = NewMovie.Rate;
            movie.storeline = NewMovie.storeline;
            movie.Poster = NewMovie.Poster;
            movie.Year = NewMovie.Year;
            context.SaveChanges();
        }
        public void Delete(int? id)
        {
            Movie movie = context.Movies.FirstOrDefault(m => m.Id == id);
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
       

    }
}
