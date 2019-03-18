using FindGavenCore.Data;
using System.Collections.Generic;
using System.Linq;
using FindGavenCore.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace FindGavenCore.Services
{
    public class GiftService : IGiftService
    {

        private readonly ApplicationDbContext _db;

        public GiftService(ApplicationDbContext db)
        {
            _db = db;
        }
        Random ran = new Random();

        public GiftService()
        {

        }

        // Søgningen efter gaver via de forskellige værdier brugeren vælger
        public List<Present> FindGifts(int page, string priceRange, string category, string who, string occasion)
        {

            occasion = occasion.ToLower();
            category = category.ToLower();
            who = who.ToLower();
            if (ValidateSearchCriteria(occasion, category, who) == false)
                return null;

            int min, max;
            SplitPrice(priceRange, out min, out max);

            var presents = _db.Present
                .Where(a => a.Price >= min && a.Price <= max)
                .Include(a => a.Tags)
                .ToList();

            var presentsTest = presents.SingleOrDefault(x => x.Name == "TestGave");
            presents.Remove(presentsTest);
            presents = presents
                .Where(a => a.Tags
                    .Any(b => b.Type == 2 && b.Value.ToLower() == category.ToLower()))
                .Where(a => a.Tags
                    .Any(b => b.Type == 3 && b.Value.ToLower() == who.ToLower()))
                .Where(a => a.Tags
                    .Any(b => b.Type == 1 && b.Value.ToLower() == occasion.ToLower()))
                    .ToList();

            return presents;
        }

        public List<Present> ListPopularGifts(int page)
        {
            var presents = _db.Present
                .OrderByDescending(a => a.Rating)
                .Skip((page - 1) * 3)
                .Take(3)
                .ToList();

            return presents;
        }

        private void SplitPrice(string priceRange, out int min, out int max)
        {
            var minMaxPrice = priceRange.Split('-').Select(x => Int32.Parse(x.Trim()));
            min = minMaxPrice.First();
            max = minMaxPrice.Last();
        }
        private bool SplitPriceByComma(string price)
        {
            if (price.Contains(','))
            {
                var priceSplit = price.Split(',');
                if (priceSplit[1].Length > 2)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        public List<Present> ListRandomGifts(int page)
        {
            var presents = _db.Present.ToList();
            return presents;
        }

        public void RandomizeGifts(List<Present> presents)
        {
            Present tempPresent;
            int num;
            if (presents != null || presents.Count > 0)
            {
                for (int i = 0; i < presents.Count; i++)
                {
                    num = ran.Next(presents.Count);
                    tempPresent = presents[i];
                    presents[i] = presents[num];
                    presents[num] = tempPresent;
                }
            }
        }

        public void IncreaseRating(int presentId)
        {
            var present = _db.Present.SingleOrDefault(a => a.Id == presentId);
            if (present == null)
            {
                throw new Exception();
            }

            present.Rating++;
            _db.SaveChanges();
        }
        public List<Present> GetAllPresents()
        {
            return _db.Present.OrderBy(x => x.Name).ToList();
        }
        public void RemoveGift(int id)
        {
            Present presentToRemove = _db.Present.Include(x => x.Tags).SingleOrDefault(x => x.Id == id);
            _db.Tags.RemoveRange(presentToRemove.Tags);
            _db.Present.Remove(presentToRemove);
            _db.SaveChanges();
        }

        private decimal ValidateGift(string price, decimal priceDec, string name, string descpription, string image, string link)
        {
            int result;
            bool succededName = int.TryParse(name, out result);
            bool succededDec = int.TryParse(descpription, out result);
            bool succededImage = int.TryParse(image, out result);
            bool succededLink = int.TryParse(link, out result);
            if ((name == null || name.Length > 400) || succededName == true)
                throw new Exception();
            else if (descpription.Length > 1000)
                throw new Exception();
            else if (price == null || SplitPriceByComma(price) == false)
                throw new Exception();
            else if (image == null || image.Length > 400 || succededImage == true)
                throw new Exception();
            else if (link == null || link.Length > 400 || succededLink == true)
                throw new Exception();
            else
                priceDec = Convert.ToDecimal(price);
            if (priceDec < 0)
                throw new Exception();
            else
                return priceDec;
        }

        public void TestValidateGift(string price, decimal priceDec, string name, string descpription, string image, string link)
        {
            int result;
            bool succededName = int.TryParse(name, out result);
            bool succededDec = int.TryParse(descpription, out result);
            bool succededImage = int.TryParse(image, out result);
            bool succededLink = int.TryParse(link, out result);
            if ((name == null || name.Length > 5))
                throw new ArgumentException();
            else if (descpription.Length > 20)
                throw new ArgumentException();
            else if (price == null || SplitPriceByComma(price) == false)
                throw new ArgumentException();
            else if (image == null || image.Length > 10 || succededImage == true)
                throw new ArgumentException();
            else if (link == null || link.Length > 10 || succededLink == true)
                throw new ArgumentException();
            else
                priceDec = Convert.ToDecimal(price);
            if (priceDec < 0)
                throw new ArgumentOutOfRangeException();
        }
        public void AddGift(string name, string description, string price, string image, string link, int providerId)
        {
            decimal priceDec = 0;
            priceDec = ValidateGift(price, priceDec, name, description, image, link);
            Provider provider = _db.Provider.SingleOrDefault(x => x.Id == providerId);

            _db.Present.Add(new Present()
            {
                Name = name,
                Description = description,
                Price = priceDec,
                Image = image,
                LinkToPresent = link,
                Provider = provider
            });
            _db.SaveChanges();
        }

        public bool ValidateSearchOccAndCat(string occasion, string category)
        {
            if ((occasion == "bryllup" && category == "legetøj") || (occasion == "bryllup" && category == "påklædning")
              || (occasion == "værtsgave" && category == "legetøj") || (occasion == "polterabend" && category == "legetøj")
              || (occasion == "polterabend" && category == "husartikler") || (occasion == "polterabend" && category == "indretning")
              || (occasion == "polterabend" && category == "påklædning"))
                return false;
            else
                return true;
        }
        public bool ValidateSearchOccAndWho(string occasion, string who)
        {
            if ((occasion == "bryllup" && who == "mand") || (occasion == "bryllup" && who == "kvinde") || (occasion == "bryllup" && who == "dreng")
                || (occasion == "bryllup" && who == "pige") || (occasion == "værtsgave" && who == "dreng") || (occasion == "værtsgave" && who == "pige")
                || (occasion == "fødselsdag" && who == "par") || (occasion == "kærestegave" && who == "par") || (occasion == "polterabend" && who == "par")
                || (occasion == "polterabend" && who == "dreng") || (occasion == "polterabend" && who == "pige") || (occasion == "indflyttergave" && who == "dreng")
                || (occasion == "indflyttergave" && who == "pige")
                )
                return false;
            else
                return true;
        }
        public bool ValieDateSearchWhoAndCat(string who, string category)
        {
            if ((who == "par" && category == "selvpleje") || (who == "par" && category == "påklædning") || (who == "par" && category == "legetøj")
                || (who == "mand" && category == "legetøj") || (who == "kvinde" && category == "legetøj"))
                return false;
            else
                return true;
        }


        public bool ValidateSearchCriteria(string occasion, string category, string who)
        {
            if (ValidateSearchOccAndCat(occasion, category) == false)
                return false;
            else if (ValidateSearchOccAndWho(occasion, who) == false)
                return false;
            else if (ValieDateSearchWhoAndCat(who, category) == false)
                return false;
            else
                return true;
        }


    }
}