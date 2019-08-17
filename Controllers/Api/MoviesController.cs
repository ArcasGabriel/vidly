using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET api/movies
        public IHttpActionResult GetMovies()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();
            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }

        // GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/movies
        [HttpPost]
        [Authorize(Roles = AppRole.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!User.IsInRole(AppRole.CanManageMovies))
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT api/movies/1
        [HttpPut]
        [Authorize(Roles = AppRole.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!User.IsInRole(AppRole.CanManageMovies))
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/movies/1
        [HttpDelete]
        [Authorize(Roles = AppRole.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!User.IsInRole(AppRole.CanManageMovies))
                return Unauthorized();

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);

            _context.SaveChanges();

            return Ok();

        }

    }
}