using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindGavenCore.Models;

namespace FindGavenCore.Services
{
   public interface IProviderService
    {
        List<Provider> GetAllProviders();
        Provider GetProviderById(int id);
        void AddProvider(string name, string description, string image);
        void RemoveProvider (int id);
    }
}
