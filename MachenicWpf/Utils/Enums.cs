using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachenicWpf.Utils {
    public enum FormType : int {
        Order = 0,
        OrderEdit = 1,
        Type1 = 2,
        Type2 = 3,
        Type3 = 4,
        Type4 = 5,
        StockPage = 6
    }
    public enum DrawingType : int {
        Type1 = 0,
        Type2 = 1,
        Type3 = 2,
        Type4 = 4
    }
    public enum TextAlignment : int {
        LeftToRight = 0,
        BottomUp = 1,
        TopDown = 2,
        RightToLeft = 3
    }
}
