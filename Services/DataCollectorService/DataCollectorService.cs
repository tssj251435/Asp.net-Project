using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FindGavenCore.Data;
using FindGavenCore.Models;
using Microsoft.EntityFrameworkCore;

namespace FindGavenCore.Services
{
    public class DataCollectorService : IDataCollectorService
    {
        private readonly ApplicationDbContext _db;
        public DataCollectorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Present> GetGiftsMatchingSpecifiedTag(string tagValue)
        {
            var presents = _db.Present
                .Include(x => x.Tags)
                .Where(x => x.Tags.Any(y => y.Value.ToLower() == tagValue.ToLower()))
                .ToList();

            return presents;
        }

        public List<Present> GetMatchingGiftsByProvider(int providerId)
        {
            var presents = _db.Present
                .Where(a => a.Provider.Id == providerId)
                .ToList();

            return presents;
        }

        public List<Present> GetMostPopularGifts(int howMany)
        {
            var presents = _db.Present
                .OrderByDescending(x => x.Rating)
                .Take(howMany)
                .ToList();

            return presents;
        }

        public List<Provider> GetNumberOfGiftsFromProvider()
        {
            var providers = _db.Provider.Include(x => x.Presents).ToList();
            return providers;
        }

        public List<Present> GetSpecificGiftsInPriceRange(int minPrice, int maxPrice)
        {
            var presents = 
                _db.Present.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();

            return presents;
        }

        public Present GetTagsOfChosenGift(int id)
        {
            var present = _db.Present.Include(x => x.Tags).SingleOrDefault(x => x.Id == id);
            return present;
        }
    }
}
