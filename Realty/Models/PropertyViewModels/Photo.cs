using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realty.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public byte[] ImageData { get; set; }
        public int PropertyId { get; set; }
    }
}
