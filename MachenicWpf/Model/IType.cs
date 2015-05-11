using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public interface IType {
       
        Dictionary<string, object> GetAllValues();
        string ToOrderDetail(bool store = false);
        void RevertModel(string detail);
        MaterialRow ShaftRow { get; set; }
        MaterialRow RollerPineRow { get; set; }
        MaterialRow BearingStandRow { get; set; }
        MaterialRow BearingRow { get; set; }
        MaterialRow SealRow { get; set; }
        MaterialRow CirclipRow { get; set; }
        string WeightOfRoller();
    }
}
