using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Realty.Models;

namespace Realty.Models
{
    public class RealtyContext : DbContext
    {
        public RealtyContext (DbContextOptions<RealtyContext> options)
            : base(options)
        {
        }

        public DbSet<Realty.Models.Property> Property { get; set; }

        public DbSet<Realty.Models.Photo> Photo { get; set; }
    }
}
