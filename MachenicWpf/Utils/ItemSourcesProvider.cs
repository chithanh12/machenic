using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachenicWpf.Utils {
    public class ItemSourcesProvider {

        public static List<int> GetBearingList(float diameter) {
            if (diameter == 63.5) {
                return new List<int> { 203 };
            }
            if (diameter == 76) {
                return new List<int> { 203, 204 };
            }
            if (diameter == 89) {
                return new List<int> { 204, 205, 206, 304, 305 };
            }
            if (diameter == 102) {
                return new List<int> { 204, 205, 206, 207, 304, 305, 306 };
            }
            if (diameter == 108) {
                return new List<int> { 204, 205, 206, 207, 208, 304, 305, 306, 307 };
            }
            if (diameter == 114) {
                return new List<int> { 204, 205, 206, 207, 208, 209, 304, 305, 306, 307 };
            }
            if (diameter == 127) {
                return new List<int> { 204, 205, 206, 207, 208, 209, 210, 304, 305, 306, 307, 308, 309 };
            }
            if (diameter == 133) {
                return new List<int> { 204, 205, 206, 207, 208, 209, 210, 304, 305, 306, 307, 308, 309 };
            }
            if (diameter == 159) {
                return new List<int> { 204, 205, 206, 207, 208, 209, 210, 304, 305, 306, 307, 308, 309, 310 };
            }
            if (diameter == 194) {
                return new List<int> { 204, 205, 206, 207, 208, 209, 210, 304, 305, 306, 307, 308, 309, 310 };
            }
            // case 219
            return new List<int> { 204, 205, 206, 207, 208, 209, 210, 304, 305, 306, 307, 308, 309, 310 };
        }
        public static List<float> GetDiameters() {
            return new List<float> {
                63.5f,
                76, 
                89, 
                102,
                108,
                114,
                127,
                133,
                159,
                194,
                219,
            };
        }
    }
}
