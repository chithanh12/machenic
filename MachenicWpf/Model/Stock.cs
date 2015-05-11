using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class Stock {
        [Key]
        public int ID { get; set; }
        public string Material { get; set; }
        public float Size { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }

    }
}
