using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class Type2ViewModel : BaseTypeViewModel {
        private float? m_c1;
        private float? m_c2;
        private float? m_c4;
        private float? m_c6;
        public float? C1 {
            get {
                return m_c1;

            }
            set {
                if (m_c1 != value) {
                    m_c1 = value;
                    NotifyChanged("C1");
                    NotifyChanged("C3");
                    NotifyChanged("C5");
                }
            }
        }
        public float? C2 {
            get {
                return m_c2;
            }
            set {
                if (m_c2 != value) {
                    m_c2 = value;
                    NotifyChanged("C2");
                    NotifyChanged("C3");
                    NotifyChanged("C5");
                }
            }
        }
        public float? C4 {
            get {
                return m_c4;
            }
            set {
                if (m_c4 != value) {
                    m_c4 = value;
                    NotifyChanged("C4");
                    NotifyChanged("C5");
                }
            }
        }
        public float? C6 {
            get {
                return m_c6;
            }
            set {
                if (m_c6 != value) {
                    m_c6 = value;
                    NotifyChanged("C6");
                }
            }
        }
        public float? C3 {
            get {
                return C1 + 2 * C2;
            }

        }
        public float? C5 {
            get {
                return C3 + 2 * C4;
            }
        }
        public float? Y7 {
            get {
                return C5;
            }
        }
        public float Y8 {
            get {
                if (Y7 <= 120) { return 0.87f; }
                if (Y7 <= 180) { return 1f; }
                if (Y7 <= 250) { return 1.15f; }
                if (Y7 <= 315) { return 1.3f; }
                if (Y7 <= 400) { return 1.4f; }
                if (Y7 <= 500) { return 1.55f; }
                if (Y7 <= 630) { return 1.75f; }
                if (Y7 <= 800) { return 2f; }
                if (Y7 <= 1000) { return 2.3f; }
                if (Y7 <= 1250) { return 2.6f; }
                if (Y7 <= 1600) { return 3.1f; }
                if (Y7 <= 2000) { return 3.7f; }
                if (Y7 <= 2500) { return 4.4f; }
                return 5.4f;
            }
        }
        public float? Y9 {
            get {
                return C1;
            }
        }
        public float Y10 {
            get {
                if (Y9 <= 120) { return 0.087f; }
                if (Y9 <= 180) { return 0.1f; }
                if (Y9 <= 250) { return 0.115f; }
                if (Y9 <= 315) { return 0.13f; }
                if (Y9 <= 400) { return 0.14f; }
                if (Y9 <= 500) { return 0.155f; }
                if (Y9 <= 630) { return 0.175f; }
                if (Y9 <= 800) { return 0.2f; }
                if (Y9 <= 1000) { return 0.23f; }
                if (Y9 <= 1250) { return 0.26f; }
                if (Y9 <= 1600) { return 0.31f; }
                if (Y9 <= 2000) { return 0.37f; }
                if (Y9 <= 2500) { return 0.44f; }
                return 0.54f;
            }
        }
        public float? Y11 {
            get {
                return C2;
            }
        }
        public float? Y12 {
            get {
                return C4;
            }
        }
        public float? Y13 {
            get {
                return C3;
            }
        }
        public float Y14 {
            get {
                if (Y13 <= 120) { return 0.087f; }
                if (Y13 <= 180) { return 0.1f; }
                if (Y13 <= 250) { return 0.115f; }
                if (Y13 <= 315) { return 0.13f; }
                if (Y13 <= 400) { return 0.14f; }
                if (Y13 <= 500) { return 0.155f; }
                if (Y13 <= 630) { return 0.175f; }
                if (Y13 <= 800) { return 0.2f; }
                if (Y13 <= 1000) { return 0.23f; }
                if (Y13 <= 1250) { return 0.26f; }
                if (Y13 <= 1600) { return 0.31f; }
                if (Y13 <= 2000) { return 0.37f; }
                if (Y13 <= 2500) { return 0.44f; }
                return 0.54f;
            }
        }
        public float? Y15 {
            get {
                return d1;
            }
        }
        public float? Y16 {
            get {
                if (Y15 <= 18) { return 0.011f; }
                if (Y15 <= 30) { return 0.013f; }
                if (Y15 <= 50) { return 0.016f; }
                return 0.019f;
            }
        }
        public float? Y17 {
            get {
                return d1 + 2;
            }
        }
        public float? Y18 {
            get {
                return 177 + L - 250 + 2 * (11 - B);
            }
        }
        public float? Y19 {
            get {
                return 247f + L - 250f + 2 * (S - 1.4f);
            }
        }
        public float? Y20 {
            get {
                return (Y7 - Y18) / 2.0f;
            }
        }
        public float? Y21 {
            get {
                return (Y19 - Y18) / 2f;
            }
        }
        public float? Y22 {
            get {
                return Y20 - Y21;
            }
        }
        public float? Y23 {
            get {
                return C6;
            }
        }
        public float Y24 {
            get {
                if (Y23 <= 3) { return 0.025f; }
                if (Y23 <= 6) { return 0.03f; }
                if (Y23 <= 10) { return 0.036f; }
                if (Y23 <= 18) { return 0.043f; }
                if (Y23 <= 30) { return 0.052f; }
                if (Y23 <= 50) { return 0.062f; }
                return 0.074f;
            }
        }
        public float? Y25 {
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
        public float? Y26 {
            get {
                return Y16;
            }
        }
        
        protected override string Validate(string properyName) {
            //Retun error message if there is error on else return empty or null string
            string validationMessgae = string.Empty;
            switch (properyName) {
                case "L":
                    if (L < 100) {
                        return "Value of L must greater than 100";
                    }
                    if (L > C1 - 2) {
                        return "Value of L must less than or equal " + (C1 - 2) + " ( L <= C1-2 )";
                    }
                    break;
                case "C1":
                    if (C1 < L + 2) {
                        return "Value of C1 must be greater or equal" + (L + 2) + " ( C1>= L+2 )";
                    }
                    break;
                case "C2":
                    if (C2 < 0) {
                        return "Value of C2 must be greater than 0";
                    }
                    break;
                case "C4":
                    if (C4 < 2) {
                        return "Value of C4 must be greater than or equal 2";
                    }
                    break;
                case "C6":
                    if (C6 < 0 || C6 > d1 - 2) {
                        return "Value of C6 must be between 0 - " + (d1 - 2) + "(0 < C6 <=d1-2)";
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
                {"L", L},
                {"Bearing", Bearing},
                {"C1", C1},
                {"C2", C2},
                {"C3", C3},
                {"C4", C4},
                {"C5", C5},
                {"C6", C6},
                {"S", S},
                {"B", B},
                {"X1", X1},
                {"X101", X101},
                {"X2", X2},
                {"X202", X202},
                {"X3", X3},
                {"X4", X4},
                {"X5", X5},
                {"X6", X6},
                {"Y7", Y7},
                {"Y8", Y8},
                {"Y9", Y9},
                {"Y10", Y10},
                {"Y11", Y11},
                {"Y12", Y12},
                {"Y13", Y13},
                {"Y14", Y14},
                {"Y15", Y15},
                {"Y16", Y16},
                {"Y17", Y17},
                {"Y18", Y18},
                {"Y19", Y19},
                {"Y20", Y20},
                {"Y21", Y21},
                {"Y22", Y22},
                {"Y23", Y23},
                {"Y24", Y24},
                {"Y25", Y25},
                {"Y26", Y26},
                {"X22", X22},
                {"X23", X23},
                {"X24", X24},
                {"X25", X25},
                {"X26", X26}
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
            builder.AppendFormat("C1: {0}\r\n", C1); //6
            builder.AppendFormat("C2: {0}\r\n", C2); //7
            builder.AppendFormat("C3: {0}\r\n", C3); //8
            builder.AppendFormat("C4: {0}\r\n", C4); //9
            builder.AppendFormat("C5: {0}\r\n", C5); //10
            builder.AppendFormat("C6: {0} \r\n", C6); //11

            builder.AppendFormat("{0}: {1} \r\n", ShaftRow.DisplayName, ShaftRow.UnitCost); //12
            builder.AppendFormat("{0}: {1}\r\n", RollerPineRow.DisplayName, RollerPineRow.UnitCost); //13
            builder.AppendFormat("{0}: {1}\r\n", BearingStandRow.DisplayName, BearingStandRow.UnitCost); //14
            builder.AppendFormat("{0}: {1}\r\n", BearingRow.DisplayName, BearingRow.UnitCost); //15
            builder.AppendFormat("{0}: {1}\r\n", SealRow.DisplayName, SealRow.UnitCost); //16
            builder.AppendFormat("{0}: {1}\r\n", CirclipRow.DisplayName, CirclipRow.UnitCost); //17

            return builder.ToString();
        }

        public override void RevertModel(string detail) {
            detail = detail.Replace("\r\n", ";");
            var arr = detail.Split(';');
            D = float.Parse(arr[0].Substring(2));
            Bearing = int.Parse(arr[1].Substring(8));
            L = float.Parse(arr[5].Substring(2));
            C1 = float.Parse(arr[6].Substring(3));
            C2 = float.Parse(arr[7].Substring(3));
            C4 = float.Parse(arr[9].Substring(3));
            C6 = float.Parse(arr[11].Substring(3));

            //InitMaterial();
            ShaftRow.UnitCost = float.Parse(arr[12].Substring(arr[12].IndexOf(":") + 1));
            RollerPineRow.UnitCost = float.Parse(arr[13].Substring(arr[13].IndexOf(":") + 1));
            BearingStandRow.UnitCost = float.Parse(arr[14].Substring(arr[14].IndexOf(":") + 1));
            BearingRow.UnitCost = float.Parse(arr[15].Substring(arr[15].IndexOf(":") + 1));
            SealRow.UnitCost = float.Parse(arr[16].Substring(arr[16].IndexOf(":") + 1));
            CirclipRow.UnitCost = float.Parse(arr[17].Substring(arr[17].IndexOf(":") + 1));
        }

        public override string WeightOfRoller() {
            return "TODO";
        }
        protected override bool InternalValidate() {
            return L.HasValue && C1.HasValue && C2.HasValue && C4.HasValue && C6.HasValue;
        }
        protected override List<string> ValidateProperties() {
            var lst = base.ValidateProperties();
            lst.AddRange(new List<string> { "C1", "C2", "C4", "C6" });
            return lst;
        }
        public override void NotifyChanged(string prop) {
            if (prop == "d1") {
                base.NotifyChanged("C6");
            }
            base.NotifyChanged(prop);
        }
        protected override void RefreshMaterial() {
            //ShaftRow.SetParameter(13);
            RollerPineRow.SetParameter(D, t);
            BearingStandRow.SetParameter(Bearing, D);
            BearingRow.SetParameter(Bearing);
            SealRow.SetParameter(Bearing);
            CirclipRow.SetParameter(d1);
            // Set Length
            //ShaftRow.Length = PdfHelper.Nearest5(A3);
            RollerPineRow.Length = PdfHelper.Nearest5(L);
            //Update weight
            //BearingStandRow.Weight = Math.Round((3.14f * ((X24 * X24 - (D1 - 22) * (D1 - 22)) / 4 * 3 + (12 * D1 + 36) / 4 * (X26 - 3)) * 7835) / 1000000000, 2);
            RollerPineRow.Weight = Math.Round(3.14f * (D * D - (D - 2 * t) * (D - 2 * t)) * PdfHelper.Nearest5(L) * 7835 / 4000000000, 2);
            //ShaftRow.Weight = Math.Round(3.14f * X13 * X13 * PdfHelper.Nearest5(A3) * 7835 / 4000000000, 2);
        }
    }
}
