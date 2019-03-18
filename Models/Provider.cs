using System;
using System.Collections.Generic;

namespace FindGavenCore.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public virtual List<Present> Presents { get; set; }
    }
}