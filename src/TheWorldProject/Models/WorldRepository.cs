﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldProject.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldRepository> _logger;

        public WorldRepository(WorldContext context, ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddStop(string tripName, /*string username*/ Stop newStop)
        {
            var trip = GetTripByName(tripName/*, username*/);

            if (trip != null)
            {
                trip.Stops.Add(newStop);
                _context.Stops.Add(newStop);
            }
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting all trips from the database");
            return _context.Trips.ToList();
        }

        public Trip GetTripByName(string tripName/*, string username*/)
        {
            return _context.Trips.Include(t => t.Stops)
                .Where(t => t.Name == tripName/* && t.UserName == username*/)
                .FirstOrDefault();
        }

        public object GetTripsByUsername(string name)
        {
            return _context.Trips.Where(t => t.UserName == name).ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
