using System;

namespace FindGavenCore.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual Present Present { get; set; }
        public int Type { get; set; }    
        
    }
}