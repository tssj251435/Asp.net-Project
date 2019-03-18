using System.Collections.Generic;

namespace FindGavenCore.Services
{
    public interface ITagService
    {
        void AddTag(int presentId, int type, string value);
        void RemoveTag(int presentId, string value);
        void AddParamValue(int type, string value);
        void RemoveParamValue( string value);
        List<string> GetAllDistinctValues(int whatType);
        bool HasTag(int presentId, string value);
        List<string> GetAllTagValues();
     
    }
}