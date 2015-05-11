using MachenicWpf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MachenicWpf.Service {
    public class MachenicContext : DbContext {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<IDMaster> IDMasters { get; set; }
    }
}
