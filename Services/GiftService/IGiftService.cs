using System.Collections.Generic;
using FindGavenCore.Models;

namespace FindGavenCore.Services
{
    public interface IGiftService
    {
        List<Present> FindGifts (int page, string priceRange, string category, string who, string occasion);
        List<Present> ListRandomGifts (int page);
        void IncreaseRating (int presentId);
        List<Present> ListPopularGifts (int page);
        void RandomizeGifts(List<Present> presents);
        void AddGift(string name, string description, string price, string image, string link, int providerId);
        void RemoveGift(int id);
        List<Present> GetAllPresents();
        bool ValidateSearchCriteria(string occasion, string category, string who);
       
       

    }
}