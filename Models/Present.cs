using System;
using System.Collections.Generic;

namespace FindGavenCore.Models
{
    public class Present
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string LinkToPresent { get; set; }
        public int Rating { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Provider Provider { get; set; }
        
    }
}