using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class Order {
        [Key]
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int OrderType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public bool Finish { get; set; }
        public string Note { get; set; }
        [NotMapped]
        public int RemainingDate {
            get {
                return ToDate.Subtract(DateTime.Now).Days;
            }
        }
        [NotMapped]
        public string DrawingTypeDisplay {
            get {
                return "Type " + OrderType;
            }
        }
        public string OrderDetail { get; set; }
    }
}
