using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class Type1ViewModel : BaseTypeViewModel {
        private float? m_a1;
        private float? m_a2;
        private float? m_a3;
        private float? m_a4;
        public float? A1 {
            get {
                return m_a1;
            }
            set {
                if (m_a1 != value) {
                    m_a1 = value;
                    NotifyChanged("A1");
                    A3 = (A1 + 2 * A2);
                }
            }
        }
        public float? A2 {
            get {
                return m_a2;
            }
            set {
                if (m_a2 != value) {
                    m_a2 = value;
                    NotifyChanged("A2");
                    A3 = (A1 + 2 * A2);
                }
            }
        }
        public float? A3 {
            get {
                return m_a3;
            }
            set {
                if (m_a3 != value) {
                    m_a3 = value;
                    NotifyChanged("A3");
                }
            }
        }
        public float? A4 {
            get {
                return m_a4;
            }
            set {
                if (m_a4 != value) {
                    m_a4 = value;
                    NotifyChanged("A4");
                }
            }
        }
        public float? X7 {
            get {
                return A3;
            }
        }
        public float X77 {
            get {
                if (X7 <= 120) return 0.87f;
                if (X7 <= 180) return 1f;
                if (X7 <= 250) return 1.15f;
                if (X7 <= 315) return 1.3f;
                if (X7 <= 400) return 1.4f;
                if (X7 <= 500) return 1.55f;
                if (X7 <= 630) return 1.75f;
                if (X7 <= 800) return 2f;
                if (X7 <= 1000) return 2.3f;
                if (X7 <= 1250) return 2.6f;
                if (X7 <= 1600) return 3.1f;
                if (X7 <= 2000) return 3.7f;
                if (X7 <= 2500) return 4.4f;
                return 5.4f;
            }
        }
        public float? X8 {
            get {
                return A1;
            }
        }
        public float X9 {
            get {
                if (X8 <= 120) return 0.087f;
                if (X8 <= 180) return 0.1f;
                if (X8 <= 250) return 0.115f;
                if (X8 <= 315) return 0.13f;
                if (X8 <= 400) return 0.14f;
                if (X8 <= 500) return 0.155f;
                if (X8 <= 630) return 0.175f;
                if (X8 <= 800) return 0.2f;
                if (X8 <= 1000) return 0.23f;
                if (X8 <= 1250) return 0.26f;
                if (X8 <= 1600) return 0.31f;
                if (X8 <= 2000) return 0.37f;
                if (X8 <= 2500) return 0.44f;
                return 0.54f;
            }
        }
        public float? X10 {
            get {
                return A2;
            }
        }
        public float X11 {
            get {
                return d1;
            }
        }
        public float X12 {
            get {
                if (X11 <= 18) return 0.011f;
                if (X11 <= 30) return 0.013f;
                if (X11 <= 50) return 0.016f;
                return 0.019f;
            }
        }

        public float X13 {
            get {
                return d1 + 2;
            }
        }
        public float? X14 {
            get {
                return A4;
            }
        }
        public float X15 {
            get {
                if (X14 <= 3) return 0.025f;
                if (X14 <= 6) return 0.03f;
                if (X14 <= 10) return 0.036f;
                if (X14 <= 18) return 0.043f;
                if (X14 <= 30) return 0.052f;
                if (X14 <= 50) return 0.062f;
                return 0.074f;
            }
        }
        public float? X16 {
            get {
                return 177 + L - 250 + 2 * (14 - B);
            }
        }

        public float? X17 {
            get {
                return 247f + L - 250f + 2 * (S - 1.4f);
            }
        }
        public float? X18 {
            get {
                return (X7 - X16) / 2.0f;
            }
        }
        public float? X19 {
            get {
                return (X17 - X16) / 2.0f;
            }
        }
        public float? X20 {
            get { return X18 - X19; }
        }
        public float X21 {
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
        public float X211 {
            get {
                return X12;
            }
        }
        protected override string Validate(string propertyName) {
            string validationMessgae = string.Empty;
            switch (propertyName) {
                case "L":
                    if (L < 100) {
                        return "Value of L must greater than 100";
                    }
                    if (L > A1 - 2) {
                        return "Value of L must less than or equal " + (A1 - 2) + " ( L <= A1-2 )";
                    }
                    break;
                case "A1":
                    if (A1 < L + 2) {
                        return "Value of A1 must be greater or equal" + (L + 2) + " ( A1>= L+2 )";
                    }
                    break;
                case "A2":
                    if (A2 < 0) {
                        return "Value of A2 must be greater than 0";
                    }
                    break;
                case "A4":
                    if (A4 < 0) {
                        return "Value of A4 must greater than 0";
                    }
                    if (A4 > d1 - 2) {
                        return "Value of A4 must less than or equal " + (d1 - 2) + " ( A4 <= d1-2 )";
                    }
                    break;

            }
            return validationMessgae;
        }

        public override Dictionary<string, object> GetAllValues() {
            return new Dictionary<string, object>{
                {"D", D},
                {"D1", D1},
                {"d1", d1},
                {"L", L},
                {"A1", A1},
                {"A2", A2},
                {"A3", A3},
                {"A4", A4},
                {"B", B},
                {"X1", X1},
                {"X101", X101},
                {"X2", X2},
                {"X202", X202},
                {"X3", X3},
                {"X4", X4},
                {"X5", X5},
                {"X6", X6},
                {"X7", X7},
                {"X8", X8},
                {"X9", X9},
                {"X10", X10},
                {"X11", X11},
                {"X12", X12},
                {"X13", X13},
                {"X14", X14},
                {"X15", X15},
                {"X16", X16},
                {"X17", X17},
                {"X18", X18},
                {"X19", X19},
                {"X20", X20},
                {"X21", X21},
                {"X22", X22},
                {"X23", X23},
                {"X24", X24},
                {"X25", X25},
                {"X26", X26},
                {"S", S},
                {"X77", X77},
               {"X211", X211},
               {"Bearing", Bearing},
               {"t", t}
            };
        }

        public override string ToOrderDetail(bool store = false) {
            var builder = new StringBuilder();
            builder.AppendFormat("D: {0}\r\n", D);
            builder.AppendFormat("Bearing: {0}\r\n", Bearing);
            builder.AppendFormat("d1: {0}\r\n", d1);
            builder.AppendFormat("D1: {0}\r\n", D1);
            builder.AppendFormat("B: {0}\r\n", B);
            builder.AppendFormat("L: {0}\r\n", L);
            builder.AppendFormat("A1: {0}\r\n", A1);
            builder.AppendFormat("A2: {0}\r\n", A2);
            builder.AppendFormat("A3: {0}\r\n", A3);
            builder.AppendFormat("A4: {0} \r\n", A4);

            builder.AppendFormat("{0}: {1} \r\n", ShaftRow.DisplayName, ShaftRow.UnitCost); //10
            builder.AppendFormat("{0}: {1}\r\n", RollerPineRow.DisplayName, RollerPineRow.UnitCost); //11
            builder.AppendFormat("{0}: {1}\r\n", BearingStandRow.DisplayName, BearingStandRow.UnitCost); //12
            builder.AppendFormat("{0}: {1}\r\n", BearingRow.DisplayName, BearingRow.UnitCost); //13
            builder.AppendFormat("{0}: {1}\r\n", SealRow.DisplayName, SealRow.UnitCost); //14
            builder.AppendFormat("{0}: {1}\r\n", CirclipRow.DisplayName, CirclipRow.UnitCost); //15

            return builder.ToString();
        }
        public override void NotifyChanged(string prop) {
            base.NotifyChanged(prop);
            if (prop == "d1") {
                base.NotifyChanged("A4");
            } else if (prop == "L") {
                base.NotifyChanged("A1");
            } else if (prop == "A1") {
                base.NotifyChanged("L");
            }
        }
        public override void RevertModel(string detail) {
            detail = detail.Replace("\r\n", ";");
            var arr = detail.Split(';');
            D = float.Parse(arr[0].Substring(2));
            Bearing = int.Parse(arr[1].Substring(8));
            L = float.Parse(arr[5].Substring(2));
            A1 = float.Parse(arr[6].Substring(3));
            A2 = float.Parse(arr[7].Substring(3));
            A4 = float.Parse(arr[9].Substring(3));

            //InitMaterial();
            ShaftRow.UnitCost = float.Parse(arr[10].Substring(arr[10].IndexOf(":") + 1));
            RollerPineRow.UnitCost = float.Parse(arr[11].Substring(arr[11].IndexOf(":") + 1));
            BearingStandRow.UnitCost = float.Parse(arr[12].Substring(arr[12].IndexOf(":") + 1));
            BearingRow.UnitCost = float.Parse(arr[13].Substring(arr[13].IndexOf(":") + 1));
            SealRow.UnitCost = float.Parse(arr[14].Substring(arr[14].IndexOf(":") + 1));
            CirclipRow.UnitCost = float.Parse(arr[15].Substring(arr[15].IndexOf(":") + 1));
        }

        protected override void RefreshMaterial() {
            ShaftRow.SetParameter(X13);
            RollerPineRow.SetParameter(D, t);
            BearingStandRow.SetParameter(Bearing, D);
            BearingRow.SetParameter(Bearing);
            SealRow.SetParameter(Bearing);
            CirclipRow.SetParameter(d1);
            // Set Length
            ShaftRow.Length = PdfHelper.Nearest5(A3);
            RollerPineRow.Length = PdfHelper.Nearest5(L);
            //Update weight
            BearingStandRow.Weight = Math.Round((3.14f * ((X24 * X24 - (D1 - 22) * (D1 - 22)) / 4 * 3 + (12 * D1 + 36) / 4 * (X26 - 3)) * 7835) / 1000000000, 2);
            RollerPineRow.Weight = Math.Round(3.14f * (D * D - (D - 2 * t) * (D - 2 * t)) * PdfHelper.Nearest5(L) * 7835 / 4000000000, 2);
            ShaftRow.Weight = Math.Round(3.14f * X13 * X13 * PdfHelper.Nearest5(A3) * 7835 / 4000000000, 2);
        }
        public override double? W1 {
            get {
                double? w1 = 3.14 / 4 * 7835 * (X13 * X13 * X16 + 2 * d1 * d1 * X18) / 1000000000;
                return w1;
            }
        }
        protected override bool InternalValidate() {
            return base.InternalValidate() && A1.HasValue && A2.HasValue && A4.HasValue;
        }
        
        protected override List<string> ValidateProperties() {
            var lst = base.ValidateProperties();
            lst.AddRange(new List<string> { "A1", "A2", "A4" });
            return lst;
        }
    }
}
