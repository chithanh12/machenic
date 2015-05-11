using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class Type3ViewModel : BaseTypeViewModel {
        private float? m_e1;
        private float? m_e2;
        private float? m_d;
        #region Properties
        public float? d {
            get {
                return m_d;
            }
            set {
                if (m_d != value) {
                    m_d = value;
                    NotifyChanged("d");
                }
            }
        }
        public float? E1 {
            get {
                return m_e1;
            }
            set {
                if (m_e1 != value) {
                    m_e1 = value;
                    NotifyChanged("E1");
                }
            }
        }
        public float? E2 {
            get {
                return m_e2;
            }
            set {
                if (m_e2 != value) {
                    m_e2 = value;
                    NotifyChanged("E2");
                }
            }
        }
        public float? E3 {
            get {
                return E1 + E2 * 2;
            }
        }
        public float? E4 {
            get {
                return (E1 - L - d) / 2;
            }
        }
        public float? U7 {
            get {
                return E3;
            }
        }
        public float U77 {
            get {
                if (U7 <= 120) { return 0.87f; }
                if (U7 <= 180) { return 1f; }
                if (U7 <= 250) { return 1.15f; }
                if (U7 <= 315) { return 1.3f; }
                if (U7 <= 400) { return 1.4f; }
                if (U7 <= 500) { return 1.55f; }
                if (U7 <= 630) { return 1.75f; }
                if (U7 <= 800) { return 2f; }
                if (U7 <= 1000) { return 2.3f; }
                if (U7 <= 1250) { return 2.6f; }
                if (U7 <= 1600) { return 3.1f; }
                if (U7 <= 2000) { return 3.7f; }
                if (U7 <= 2500) { return 4.4f; }
                return 5.4f;
            }
        }
        public float? U8 {
            get {
                return E1;
            }
        }
        public float U9 {
            get {
                if (U8 <= 120) { return 0.087f; }
                if (U8 <= 180) { return 0.1f; }
                if (U8 <= 250) { return 0.115f; }
                if (U8 <= 315) { return 0.13f; }
                if (U8 <= 400) { return 0.14f; }
                if (U8 <= 500) { return 0.155f; }
                if (U8 <= 630) { return 0.175f; }
                if (U8 <= 800) { return 0.2f; }
                if (U8 <= 1000) { return 0.23f; }
                if (U8 <= 1250) { return 0.26f; }
                if (U8 <= 1600) { return 0.31f; }
                if (U8 <= 2000) { return 0.37f; }
                if (U8 <= 2500) { return 0.44f; }
                return 0.54f;
            }
        }
        public float? U10 {
            get {
                return E2;
            }
        }
        public float? U11 {
            get {
                return d1;
            }
        }
        public float? U12 {
            get {
                if (U11 <= 18) { return 0.011f; }
                if (U11 <= 30) { return 0.013f; }
                if (U11 <= 50) { return 0.016f; }
                return 0.019f;
            }
        }
        public float U13 {
            get {
                return d1 + 2;
            }
        }
        public float? U14 {
            get {
                return d;
            }
        }
        public float? U15 {
            get {
                return 177 + L - 250 + 14 - B;
            }
        }
        public float? U16 {
            get {
                return 247f + L - 250 + S - 1.4f;
            }
        }
        public float? U17 {
            get {
                return (U7 - U15) / 2;
            }
        }
        public float? U18 {
            get {
                return (U16 - U15) / 2;
            }
        }
        public float? U19 {
            get {
                return U17 - U18;
            }
        }
        public float? U20 {
            get {
                if (d1 == 17) return 16f;
                if (d1 == 20) return 18.6f;
                if (d1 == 25) return 23.5f;
                if (d1 == 30) return 28.5f;
                if (d1 == 35) return 33f;
                if (d1 == 40) return 37.5f;
                if (d1 == 45) return 42.5f;
                return 47.5f;
            }
        }
        public float? U21 {
            get {
                return U12;
            }
        }
        #endregion
        protected override string Validate(string propertyName) {
            string validationMessgae = string.Empty;
            switch (propertyName) {
                case "L":
                    if (L < 100) {
                        return "Value of L must greater than 100";
                    }

                    break;
                case "d":
                    if (d < 0 || d > d1 - 2) {
                        return "Value of d must be between 0-" + (d1 - 2) + " (0 < d <= d1-2)";
                    }
                    break;
                case "E1":
                    if (E1 < L + 2 + d) {
                        return "Value of E1 must be greater than " + (L + 2 + d) + " ( E1 >= L + 2 + d)";
                    }
                    break;
                case "E2":
                    if (E2 < d / 2 + 2) {
                        return "Value of C4 must be greater than " + (d / 2 + 2) + " (E2 >= d/2 + 2)";
                    }
                    break;

            }
            return validationMessgae;
        }

        public override Dictionary<string, object> GetAllValues() {
            return new Dictionary<string, object> {
                 {"D", D},
                {"D1", D1},
                {"d1", d1},
                {"d", d},
                {"L", L},
                {"Bearing", Bearing},
                {"E1", E1},
                {"E2", E2},
                {"E3", E3},
                {"E4", E4},
                {"B", B},
                {"X1", X1},
                {"X101", X101},
                {"X2", X2},
                {"X202", X202},
                {"X3", X3},
                {"X4", X4},
                {"X5", X5},
                {"X6", X6},
                {"X22", X22},
                {"X23", X23},
                {"X24", X24},
                {"X25", X25},
                {"X26", X26},
                {"S", S},
                {"U7", U7},
                {"U77", U77},
                {"U8", U8},
                {"U9", U9},
                {"U10", U10},
                {"U11", U11},
                {"U12", U12},
                {"U13", U13},
                {"U14", U14},
                {"U15", U15},
                {"U16", U16},
                {"U17", U17},
                {"U18", U18},
                {"U19", U19},
                {"U20", U20},
                {"U21", U21}
            };
        }

        public override string ToOrderDetail(bool store = false) {
            var builder = new StringBuilder();
            builder.AppendFormat("D: {0}\r\n", D); //0
            builder.AppendFormat("Bearing: {0}\r\n", Bearing); //1
            builder.AppendFormat("d1: {0}\r\n", d1); //2
            builder.AppendFormat("D1: {0}\r\n", D1); //3
            builder.AppendFormat("B: {0}\r\n", B); //4
            builder.AppendFormat("L: {0}\r\n", L); //5
            builder.AppendFormat("d: {0}\r\n", d); //6
            builder.AppendFormat("E1: {0}\r\n", E1); //7
            builder.AppendFormat("E2: {0}\r\n", E2); //8

            builder.AppendFormat("{0}: {1} \r\n", ShaftRow.DisplayName, ShaftRow.UnitCost); //9
            builder.AppendFormat("{0}: {1}\r\n", RollerPineRow.DisplayName, RollerPineRow.UnitCost); //10
            builder.AppendFormat("{0}: {1}\r\n", BearingStandRow.DisplayName, BearingStandRow.UnitCost); //11
            builder.AppendFormat("{0}: {1}\r\n", BearingRow.DisplayName, BearingRow.UnitCost); //12
            builder.AppendFormat("{0}: {1}\r\n", SealRow.DisplayName, SealRow.UnitCost); //13
            builder.AppendFormat("{0}: {1}\r\n", CirclipRow.DisplayName, CirclipRow.UnitCost); //14

            return builder.ToString();
        }

        public override void RevertModel(string detail) {
            detail = detail.Replace("\r\n", ";");
            var arr = detail.Split(';');
            D = float.Parse(arr[0].Substring(2));
            Bearing = int.Parse(arr[1].Substring(8));
            L = float.Parse(arr[5].Substring(2));
            d = float.Parse(arr[6].Substring(3));
            E1 = float.Parse(arr[7].Substring(3));
            E2 = float.Parse(arr[8].Substring(3));

            //InitMaterial();
            ShaftRow.UnitCost = float.Parse(arr[9].Substring(arr[9].IndexOf(":") + 1));
            RollerPineRow.UnitCost = float.Parse(arr[10].Substring(arr[10].IndexOf(":") + 1));
            BearingStandRow.UnitCost = float.Parse(arr[11].Substring(arr[11].IndexOf(":") + 1));
            BearingRow.UnitCost = float.Parse(arr[12].Substring(arr[12].IndexOf(":") + 1));
            SealRow.UnitCost = float.Parse(arr[13].Substring(arr[13].IndexOf(":") + 1));
            CirclipRow.UnitCost = float.Parse(arr[14].Substring(arr[14].IndexOf(":") + 1));
        }

        protected override void RefreshMaterial() {
            ShaftRow.SetParameter(E3);
            RollerPineRow.SetParameter(D, t);
            BearingStandRow.SetParameter(Bearing, D);
            BearingRow.SetParameter(Bearing);
            SealRow.SetParameter(Bearing);
            CirclipRow.SetParameter(d1);
            // Set Length
            ShaftRow.Length = PdfHelper.Nearest5(E3);
            RollerPineRow.Length = PdfHelper.Nearest5(L);
            //Update weight
            BearingStandRow.Weight = Math.Round((3.14f * ((X24 * X24 - (D1 - 22) * (D1 - 22)) / 4 * 3 + (12 * D1 + 36) / 4 * (X26 - 3)) * 7835) / 1000000000, 2);
            RollerPineRow.Weight = Math.Round(3.14f * (D * D - (D - 2 * t) * (D - 2 * t)) * PdfHelper.Nearest5(L) * 7835 / 4000000000, 2);
            ShaftRow.Weight = Math.Round(3.14f * U13 * U13 * PdfHelper.Nearest5(E3) * 7835 / 4000000000, 2);
        }
        protected override bool InternalValidate() {
            return base.InternalValidate() && d.HasValue && E1.HasValue && E2.HasValue ;
        }
        public override void NotifyChanged(string prop) {
            base.NotifyChanged(prop);
            if (prop == "d1") {
                base.NotifyChanged("d");
            }
        }
        public override double? W1 {
            get {
                return 3.14 / 4 * 7835 * (U13 * U13 * U15 + 2 * d1 * d1 * U17) / 1000000000;
            }
        }
        protected override List<string> ValidateProperties() {
            var lst = base.ValidateProperties();
            lst.AddRange(new List<string> {
                "E1", "E2","d"
            });
            return lst;
        }
    }
}
