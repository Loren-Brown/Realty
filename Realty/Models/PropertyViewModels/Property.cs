using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realty.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string OwnerId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public float SalesPrice { get; set; }
        public DateTime DateListed { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string GarageSize { get; set; }
        public int SquareFeet { get; set; }
        public float LotSize { get; set; }
        public string Description { get; set; }
    }
}
