using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindGavenCore.Models
{
    public class EditViewModel
    {
        public int PresentId { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int ProviderId { get; set; }
        public string ErrorMessage { get; set; }
        public List<Provider> Providers { get; set; }
        public List<Tag> Tags { get; set; }
        public int WhatType { get; set; }
        public List<Present> Presents { get; set; } = new List<Present>();

        public List<string> ParamValues { get; set; }
        public string Headline { get; set; }

        public string TypeOccAsString { get; set; } = "Anledning";
        public string TypeCatAsString { get; set; } = "Kategori";
        public string TypeWhoAsString { get; set; } = "Modtager";
        public string TagValue { get; set; }
        public int TopGifts { get; set; }
        public Present ChosenPresent { get; set; }
        public Provider ChosenProvider { get; set; }

    }
}
