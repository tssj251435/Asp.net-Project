using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindGavenCore.Models;

namespace FindGavenCore.Services
{
    public interface IDataCollectorService 
    {
        List<Present> GetSpecificGiftsInPriceRange(int minPrice, int maxPrice);
        Present GetTagsOfChosenGift(int id);
        List<Present> GetGiftsMatchingSpecifiedTag(string tagValue);
        List<Present> GetMostPopularGifts(int howMany);
        List<Present> GetMatchingGiftsByProvider(int id);
        List<Provider> GetNumberOfGiftsFromProvider();


    }
}
