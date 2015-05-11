using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MachenicWpf.Utils {
    public class PositionProvider {
        static Dictionary<int, Dictionary<int, List<ImgPos>>> s_data;
        static List<BearingMapping> m_bearingMapping;
        static PositionProvider s_current;
        static object m_locker = new object();
        public const int FONT_SIZE = 20;
        public static PositionProvider Current {
            get {
                if (s_current == null) {
                    lock (m_locker) {
                        if (s_current == null) {
                            s_current = new PositionProvider();
                        }
                    }
                }
                return s_current;
            }
        }
        static PositionProvider() {
            s_data = new Dictionary<int, Dictionary<int, List<ImgPos>>>();
            m_bearingMapping = new List<BearingMapping>();
            LoadData();
            LoadBearing();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Type 1, 2,3 or 4</param>
        /// <param name="imageNo">The number of image in that type</param>
        /// <returns></returns>
        public List<ImgPos> GetPositionInImage(int type, int imageNo) {
            if (s_data.ContainsKey(type)) {
                return s_data[type][imageNo];
            }
            throw new NotSupportedException("This type hasn't supportted!");
        }

        public BearingMapping GetBearningMapping(float bearing) {
            return m_bearingMapping.FirstOrDefault(x => x.Bearing == bearing);
        }

        private static void LoadData() {
            XmlDocument doc = new XmlDocument();
            doc.Load("Data.xml");
            XmlNodeList typeNodes = doc.SelectNodes("//Type");
            foreach (XmlNode node in typeNodes) {
                var t = int.Parse(node.Attributes["v"].Value);
                var data = new Dictionary<int, List<ImgPos>>();
                // Loop all Picture
                foreach (XmlNode pic in node.ChildNodes) {
                    var picNo = int.Parse(pic.Attributes["v"].Value);
                    var lst = new List<ImgPos>();
                    foreach (XmlNode l in pic.ChildNodes) {
                        var item = new ImgPos();
                        item.Name = l.Attributes["n"].Value;
                        float x, y; int s, v;
                        if (float.TryParse(l.Attributes["x"].Value, out x)) {
                            item.x = x;
                        }
                        if (float.TryParse(l.Attributes["y"].Value, out y)) {
                            item.y = y;
                        }
                        if (int.TryParse(l.Attributes["v"].Value, out v)) {
                            item.textmode = (TextAlignment)v;
                        }
                        if (int.TryParse(l.Attributes["s"].Value, out s)) {
                            item.fontSize = s;
                        } else {
                            item.fontSize = FONT_SIZE;
                        }
                        lst.Add(item);
                    }
                    data.Add(picNo, lst);
                }
                s_data.Add(t, data);
            }
        }

        private static void LoadBearing() {
            XmlDocument doc = new XmlDocument();
            doc.Load("Bearing.xml");
            XmlNodeList typeNodes = doc.SelectNodes("//item");
            foreach (XmlNode node in typeNodes) {
                var mapping = new BearingMapping();
                mapping.Bearing = float.Parse(node.Attributes["b"].Value);
                mapping.d1 = float.Parse(node.Attributes["d1"].Value);
                mapping.D1 = float.Parse(node.Attributes["D1"].Value);
                mapping.B = float.Parse(node.Attributes["B"].Value);
                m_bearingMapping.Add(mapping);
            }
        }
    }
    public class BearingMapping {
        public float Bearing { get; set; }
        public float d1 { get; set; }
        public float D1 { get; set; }
        public float B { get; set; }
    }
}
