using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindGavenCore.Models
{
    public class AddPicturesToGalleryViewModel
    {
        public List<TinymceImages> Images { get; set; } = new List<TinymceImages>();
    }
    public class TinymceImages
    {
        public string title { get; set; }
        public string value { get; set; }
    }
}
