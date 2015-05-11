using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace MachenicWpf.Utils {
    public class ImgHelper {
        private const int FONT_SIZE = 20;
        public static string GenerateTemp(int type, int imgIndex, string source, Dictionary<string, object> values) {
            var ext = Path.GetExtension(source);
            var temp = "temp" + Guid.NewGuid() + ext;
            File.Copy(source, temp);
            using (var img = Image.FromFile(source)) {
                using (var g = Graphics.FromImage(img)) {
                    var imgPositions = PositionProvider.Current.GetPositionInImage(type, imgIndex);
                    foreach (var pos in imgPositions) {
                        DrawText(g, values[pos.Name].ToString(), pos.x, pos.y, pos.textmode, pos.fontSize);
                    }
                }
                img.Save(temp);
            }
            return temp;
        }
        private static void DrawText(Graphics g, string value, float x, float y, TextAlignment type, int fontSize = FONT_SIZE) {
            float angle = 0;
            var font = new Font("times new roman", fontSize);
            var left2right = true;
            if (type == TextAlignment.LeftToRight) {
                angle = 360;
            } else if (type == TextAlignment.BottomUp) {
                angle = 270;
            } else if (type == TextAlignment.TopDown) {
                angle = 90;
            } else if (type == TextAlignment.RightToLeft) {
                angle = 360;
                left2right = false;
            }
            DrawText(g, value, x, y, angle, font, left2right);
        }

        private static void DrawText(Graphics g, string value, float x, float y, float angle, Font font, bool leftToRight = true) {
            var rec = g.MeasureString(value, font);
            g.TranslateTransform(x, y);
            g.RotateTransform(angle);
            g.TranslateTransform(0, 0 - rec.Height);
            if (!leftToRight) {
                g.TranslateTransform(-rec.Width, 0);
            }
            g.DrawString(value, font, Brushes.Black, new PointF(0, 0));

            //TODO:REMOVE DEBUG ONLY
            //using (var pen = new Pen(Color.Red, 1)) {
            //    g.DrawRectangle(pen, 0, 0, rec.Width, rec.Height);
            //}

            g.ResetTransform();
        }

    }
}
