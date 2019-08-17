using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // POST api/rentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _context.Customers
                .Single(c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies
                .Where(m => newRentalDto.MovieIds
                .Contains(m.Id));
            foreach (var movie in movies)
            {
                if (movie.NumberAvailability == 0)
                    return BadRequest("Movie is not available");
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                };
                movie.NumberAvailability--;
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}