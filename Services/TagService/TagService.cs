using FindGavenCore.Data;
using FindGavenCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace FindGavenCore.Services
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _db;
        public TagService(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public void AddTag(int presentId, int type, string value)
        {

            if (!HasTag(presentId, value))
            {
                Present present = _db.Present.SingleOrDefault(x => x.Id == presentId);
                _db.Tags.Add(new Tag() { Present = present, Type = type, Value = value });
                _db.SaveChanges();
            }
            else
                throw new System.Exception();
        }


        public List<string> GetAllDistinctValues(int whatType)
        {
            return _db.Tags.Where(x => x.Type == whatType).
                Select(x => x.Value).
                Distinct().
                ToList();
        }
        public List<string> GetAllTagValues()
        {          
            return _db.Tags.Where(x => x.Type == 1 || x.Type == 2 || x.Type == 3).Select(x => x.Value).Distinct().ToList();        
        }
        public bool HasTag(int presentId, string value)
        {
         
            Present present = _db.Present.Include(x => x.Tags).SingleOrDefault(x => x.Id == presentId);
            foreach (var tag in present.Tags)
            {
                if (tag.Value.ToLower() == value.ToLower())
                    return true;
            }
            return false;
        }

        
        public void AddParamValue(int type, string value)
        {
            Present present = _db.Present.Include(x => x.Tags).SingleOrDefault(x => x.Name == "TestGave");
            if (value == null)
                throw new System.Exception();
            foreach(var tag in present.Tags)
            {
                if (value == tag.Value)
                    throw new System.Exception();
            }
            _db.Tags.Add(new Tag() { Present = present, Type = type, Value = value });
            _db.SaveChanges();
        }

        public void RemoveParamValue(string value)
        {
            var tags = _db.Tags.Where(x => x.Value.ToLower() == value.ToLower()).ToList();
            _db.Tags.RemoveRange(tags);
            _db.SaveChanges();
        }

        public void RemoveTag(int presentId, string value)
        {      
            Present present = _db.Present.Single(x => x.Id == presentId);

            Tag tagToRemove = _db.Tags.SingleOrDefault(x => x.Present == present && x.Value == value);
            if (tagToRemove != null)
            {
                _db.Tags.Remove(tagToRemove);
                _db.SaveChanges();
            }
            else
            {
                throw new System.Exception(); 
            }

        }

    }
}