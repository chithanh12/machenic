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
        public float? X1 { get { return L; } }
        public float X101 {
            get {
                if (X1 <= 120) return 0.87f;
                if (X1 <= 180) return 1f;
                if (X1 <= 250) return 1.15f;
                if (X1 <= 315) return 1.3f;
                if (X1 <= 400) return 1.4f;
                if (X1 <= 500) return 1.55f;
                if (X1 <= 630) return 1.75f;
                if (X1 <= 800) return 2f;
                if (X1 <= 1000) return 2.3f;
                if (X1 <= 1250) return 2.6f;
                if (X1 <= 1600) return 3.1f;
                if (X1 <= 2000) return 3.7f;
                if (X1 <= 2500) return 4.4f;
                return 5.4f;
            }
        }
        public float? X2 {
            get { return X1 - 16; }
        }
        public float X202 {
            get {
                if (X2 <= 120) return 0.087f;
                if (X2 <= 180) return 0.1f;
                if (X2 <= 250) return 0.115f;
                if (X2 <= 315) return 0.13f;
                if (X2 <= 400) return 0.14f;
                if (X2 <= 500) return 0.155f;
                if (X2 <= 630) return 0.175f;
                if (X2 <= 800) return 0.2f;
                if (X2 <= 1000) return 0.23f;
                if (X2 <= 1250) return 0.26f;
                if (X2 <= 1600) return 0.31f;
                if (X2 <= 2000) return 0.37f;
                if (X2 <= 2500) return 0.44f;
                return 0.54f;
            }
        }
        public float X3 {
            get { return D; }
        }
        public float t {
            get {
                if (D == 63.5 || D == 76) {
                    return 3.5f;

                } else if (D == 89) {
                    return 3.0f;
                } else if (D == 102) {
                    return 3.0f;
                } else if (D == 108) {
                    return 3.0f;
                } else if (D == 114) {
                    return 3.5f;
                } else if (D == 127) {
                    return 3.0f;
                } else if (D == 133) {
                    return 3.0f;
                } else if (D == 159) {
                    return 4.0f;
                } else if (D == 194) {
                    return 7.0f;
                }

                return 8.0f;

            }
        }
        public float X4 {
            get {


                return X3 - 2 * t;

            }
        }
        public float X5 {
            get {
                return X4 + 1;
            }
        }
        public float X6 {
            get {
                if (X5 <= 80) return 0.019f;
                if (X5 <= 120) return 0.022f;
                if (X5 <= 180) return 0.025f;
                return 0.029f;
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
                {"B", B},
                {"X1", X1},
                {"X101", X101},
                {"X2", X2},
                {"X202", X202},
                {"X3", X3},
                {"X4", X4},
                {"X5", X5},
                {"X6", X6},
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
            builder.AppendFormat("C1: {0}\r\n", C1);
            builder.AppendFormat("C2: {0}\r\n", C2);
            builder.AppendFormat("C3: {0}\r\n", C3);
            builder.AppendFormat("C4: {0}\r\n", C4);
            builder.AppendFormat("C5: {0}\r\n", C5);
            builder.AppendFormat("C6: {0} \r\n",C6);

            builder.AppendFormat("{0}: {1} \r\n", ShaftRow.DisplayName, ShaftRow.UnitCost); //10
            builder.AppendFormat("{0}: {1}\r\n", RollerPineRow.DisplayName, RollerPineRow.UnitCost); //11
            builder.AppendFormat("{0}: {1}\r\n", BearingStandRow.DisplayName, BearingStandRow.UnitCost); //12
            builder.AppendFormat("{0}: {1}\r\n", BearingRow.DisplayName, BearingRow.UnitCost); //13
            builder.AppendFormat("{0}: {1}\r\n", SealRow.DisplayName, SealRow.UnitCost); //14
            builder.AppendFormat("{0}: {1}\r\n", CirclipRow.DisplayName, CirclipRow.UnitCost); //15

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
            ShaftRow.UnitCost = float.Parse(arr[10].Substring(arr[10].IndexOf(":") + 1));
            RollerPineRow.UnitCost = float.Parse(arr[11].Substring(arr[11].IndexOf(":") + 1));
            BearingStandRow.UnitCost = float.Parse(arr[12].Substring(arr[12].IndexOf(":") + 1));
            BearingRow.UnitCost = float.Parse(arr[13].Substring(arr[13].IndexOf(":") + 1));
            SealRow.UnitCost = float.Parse(arr[14].Substring(arr[14].IndexOf(":") + 1));
            CirclipRow.UnitCost = float.Parse(arr[15].Substring(arr[15].IndexOf(":") + 1));
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
            //ShaftRow.SetParameter(X13);
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
