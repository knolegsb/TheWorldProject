using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorldProject.Models;
using TheWorldProject.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorldProject.Controllers.Api
{
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private ILogger<TripsController> _logger;
        private IWorldRepository _repository;

        public TripsController(IWorldRepository repository, ILogger<TripsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            //if (true) return new object { "bad" };
            //return Ok(new Trip() { Name = "My Trip" });
            //return Ok(_repository.GetAllTrips().ToList());
            try
            {
                var results = _repository.GetAllTrips();
                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
            }
            catch (Exception ex)
            {
                // ToDo Logging
                return BadRequest("Error occurred");
            }
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]TripViewModel theTrip)
        {
            if (ModelState.IsValid)
            {
                //var newTrip = new Trip()
                //{
                //    Name = theTrip.Name,
                //    DateCreated = theTrip.DateCreated
                //};

                var newTrip = Mapper.Map<Trip>(theTrip);

                //return Created($"api/trips/{theTrip.Name}", newTrip);
                return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
            }

            return BadRequest("Bad data");
        }
    }
}
