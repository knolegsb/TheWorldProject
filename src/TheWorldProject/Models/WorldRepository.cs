using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorldProject.Models
{
    public class WorldRepository : IWorldRepository
    {
        public void AddStop(string tripName, string username, Stop newStop)
        {
            throw new NotImplementedException();
        }

        public void AddTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            throw new NotImplementedException();
        }

        public Trip GetTripByName(string tripName, string username)
        {
            throw new NotImplementedException();
        }

        public object GetTripsByUsername(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
