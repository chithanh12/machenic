using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class IDMaster {
        [Key]
        public string TableName { get; set; }
        public int CurrentID { get; set; }
    }
}
