using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindGavenCore.Data;
using FindGavenCore.Models;
using Microsoft.EntityFrameworkCore;

namespace FindGavenCore.Services
{
    public class ProviderService : IProviderService
    {
        private readonly ApplicationDbContext _db;
        public ProviderService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddProvider(string name, string description, string image)
        {
            if (name == null || name.Length == 0)
                throw new Exception();
            else
            {
                _db.Provider.Add(new Provider() { Name = name, Description = description, Image = image });
                _db.SaveChanges();
            }
        }


        public List<Provider> GetAllProviders()
        {
            var providers = _db.Provider.ToList();
            return providers;
        }
        public Provider GetProviderById(int id)
        {
            var provider = _db.Provider.SingleOrDefault(x => x.Id == id);
            return provider;
        }

        public void RemoveProvider(int id)
        {
            var provider = _db.Provider
                .Include(x => x.Presents)
                    .ThenInclude(x => x.Tags)
                .FirstOrDefault(x => x.Id == id);

            provider.Presents.ForEach(x => _db.Tags.RemoveRange(x.Tags));
            _db.Present.RemoveRange(provider.Presents);
            _db.Remove(provider);
            _db.SaveChanges();
        }
    }
}
