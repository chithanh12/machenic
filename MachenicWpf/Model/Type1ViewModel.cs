using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class Type1ViewModel : BaseViewModel, IType {
        public List<float> DiameterList { get; set; }
        public ObservableCollection<int> BearingList { get; set; }
        public Type1ViewModel() {
            InitMaterial();
            DiameterList = ItemSourcesProvider.GetDiameters();
            BearingList = new ObservableCollection<int>();
            D = DiameterList.First();
            L = 100;
        }
        #region Fields
        private float m_a1;
        private float m_a2;
        private float m_l;
        private float m_a4;
        private float m_d;
        private float m_b;
        private float m_d1;
        private float m_D1;
        private float m_a3;
        private int m_bearing;
        private float m_minA1;
        #endregion Fields
        #region PropertyValue
        public float A1 {
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
        public float A2 {
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
        public float A3 {
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
        public float A4 {
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
        public float B {
            get { return m_b; }
            set {
                if (m_b != value) {
                    m_b = value;
                    NotifyChanged("B");
                }
            }
        }
        public int Bearing {
            get { return m_bearing; }
            set {
                if (m_bearing != value) {
                    m_bearing = value;
                    NotifyChanged("Bearing");
                    var mapping = PositionProvider.Current.GetBearningMapping(value);
                    d1 = mapping.d1;
                    D1 = mapping.D1;
                    B = mapping.B;
                }
            }
        }
        public float D {
            get { return m_d; }
            set {
                if (m_d != value) {
                    m_d = value;
                    NotifyChanged("D");
                    var bearing = Bearing;
                    var bearingList = ItemSourcesProvider.GetBearingList(value);
                    BearingList.Clear();
                    foreach (var i in bearingList) {
                        BearingList.Add(i);
                    }
                    if (bearingList.Contains(bearing)) {
                        Bearing = bearing;
                        NotifyChanged("Bearing");
                    } else {
                        Bearing = bearingList.First();
                    }

                }
            }
        }
        public float D1 {
            get { return m_D1; }
            set {
                if (m_D1 != value) {
                    m_D1 = value;
                    NotifyChanged("D1");
                    NotifyChanged("MaxA4");
                }
            }
        }

        public float d1 {
            get {
                return m_d1;
            }
            set {
                if (m_d1 != value) {
                    m_d1 = value;
                    NotifyChanged("d1");
                }
            }
        }
        public float L {
            get { return m_l; }
            set {
                if (m_l != value) {
                    m_l = value;
                    NotifyChanged("L");
                    MinA1 = L + 2;
                    if (A1 < MinA1) {
                        A1 = MinA1;
                    }
                }
            }
        }
        public float MinA1 {
            get { return m_minA1; }
            set {
                if (m_minA1 != value) {
                    m_minA1 = value;
                    NotifyChanged("MinA1");
                }
            }
        }
        public float MaxA4 {
            get { return d1 -2; }
            
        }
        public float X1 { get { return L; } }
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
        public float X2 {
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
        public float X7 {
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
        public float X8 {
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
        public float X10 {
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
        public float X13 {
            get {
                return d1 + 2;
            }
        }
        public float X14 {
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
        public float X16 {
            get {
                return 177 + L - 250 + 2 * (14 - B);
            }
        }
        public float S {
            get {
                if (d1 == 17) return 1.4f;
                if (d1 == 20) return 1.4f;
                if (d1 == 25) return 1.4f;
                if (d1 == 30) return 1.4f;
                if (d1 == 35) return 1.9f;
                if (d1 == 40) return 1.9f;
                if (d1 == 45) return 1.9f;
                return 2.2f;
            }
        }
        public float X17 {
            get {
                return 247f + L - 250f + 2 * (S - 1.4f);
            }
        }
        public float X18 {
            get {
                return (X7 - X16) / 2.0f;
            }
        }
        public float X19 {
            get {
                return (X17 - X16) / 2.0f;
            }
        }
        public float X20 {
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
        public float X22 {
            get {
                return D1;
            }
        }
        public float X23 {
            get {
                if (X22 <= 50) return 0.016f;
                if (X22 <= 80) return 0.019f;
                if (X22 <= 120) return 0.022f;
                if (X22 <= 180) return 0.025f;
                return 0.029f;
            }
        }
        public float X24 {
            get {
                return X5;
            }
        }
        public float X25 {
            get {
                return X6;
            }
        }
        public float X26 {
            get {
                return 28 + B - 14;
            }
        }
        #endregion PropertyValue
        #region Material
        public MaterialRow ShaftRow { get; set; }
        public MaterialRow RollerPineRow { get; set; }
        public MaterialRow BearingStandRow { get; set; }
        public MaterialRow BearingRow { get; set; }
        public MaterialRow SealRow { get; set; }
        public MaterialRow CirclipRow { get; set; }
        #endregion Material

        private void InitMaterial() {
            ShaftRow = new MaterialRow("Shaft Ø{0}") { Id = 1, Quantity = 1, Unit = "kg" };
            RollerPineRow = new MaterialRow("Roller pipe Ø{0} x {1}") { Id = 2, Quantity = 1, Unit = "kg" };
            BearingStandRow = new MaterialRow("Bearing stand {0}-{1}") { Id = 3, Quantity = 2, Unit = "kg" };
            BearingRow = new MaterialRow("Bearing {0}") { Id = 4, Quantity = 2, Unit = "pcs" };
            SealRow = new MaterialRow("Seal for bearing {0}") { Id = 5, Quantity = 2, Unit = "pcs" };
            CirclipRow = new MaterialRow("Circlip for shaft Ø{0}") { Id = 6, Quantity = 2, Unit = "pcs" };
        }

        public Dictionary<string, object> GetAllValues() {
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

        public string ToOrderDetail(bool store = false) {
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

        public void RevertModel(string detail) {
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


        public override void NotifyChanged(string prop) {
            base.NotifyChanged(prop);
            RefreshMaterial();
        }
        private void RefreshMaterial() {
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
            BearingStandRow.Weight =  Math.Round((3.14f * ((X24 * X24 - (D1 - 22) * (D1 - 22)) / 4 * 3 + (12 * D1 + 36) / 4 * (X26 - 3)) * 7835) / 1000000000, 2);
            RollerPineRow.Weight = Math.Round( 3.14f * (D * D - (D - 2 * t) * (D - 2 * t)) * PdfHelper.Nearest5(L) * 7835 / 4000000000,2);
            ShaftRow.Weight = Math.Round( 3.14f * X13 * X13 * PdfHelper.Nearest5(A3) * 7835 / 4000000000,2);
        }


        public string WeightOfRoller() {
            return W.ToString();
        }
        public double W {
            get {
                double w= Math.Round(W1 + W2 + 2 * W3 + 2 * W4 + 2 * W5 + 2 * W6, 2);
                return w;
            }
        }
        public double W1 {
            get {
                double w1= 3.14 / 4 * 7835 * (X13 * X13 * X16 + 2 * d1 * d1 * X18)/ 1000000000;
                return w1;
            }
        }
        public double W2 {
            get {
                double w2= 3.14 * (D * D - (D - 2 * t) * (D - 2 * t)) * L * 7835 / 4000000000;
                return w2;
            }
        }
        public double W3 {
            get {
                double w3 = 3.14 * ((X24 * X24 - (D1 - 22) * (D1 - 22)) / 4 * 3 + (12 * D1 + 36) / 4 * (X26 - 3)) * 7835 / 1000000000;
                return w3;
            }
        }
        public double W4 {
            get {
                if (Bearing == 203) { return 0.065; }
                if (Bearing == 204) { return 0.11; }
                if (Bearing == 205) { return 0.13; }
                if (Bearing == 206) { return 0.2; }
                if (Bearing == 207) { return 0.29; }
                if (Bearing == 208) { return 0.37; }
                if (Bearing == 209) { return 0.41; }
                if (Bearing == 210) { return 0.46; }
                if (Bearing == 304) { return 0.14; }
                if (Bearing == 305) { return 0.23; }
                if (Bearing == 306) { return 0.35; }
                if (Bearing == 307) { return 0.46; }
                if (Bearing == 308) { return 0.63; }
                if (Bearing == 309) { return 0.83; }
                return 1.05;
            }
        }
        public double W5 {
            get {
                if (Bearing == 203) { return 0.112; }
                if (Bearing == 204) { return 0.155; }
                if (Bearing == 205) { return 0.174; }
                if (Bearing == 206) { return 0.256; }
                if (Bearing == 207) { return 0.356; }
                if (Bearing == 208) { return 0.448; }
                if (Bearing == 209) { return 0.485; }
                if (Bearing == 210) { return 0.514; }
                if (Bearing == 304) { return 0.212; }
                if (Bearing == 305) { return 0.298; }
                if (Bearing == 306) { return 0.407; }
                if (Bearing == 307) { return 0.513; }
                if (Bearing == 308) { return 0.652; }
                if (Bearing == 309) { return 0.793; }
                return 0.943;
            }
        }
        public double W6 {
            get {
                if (d1 == 17) { return 0.001; }
                if (d1 == 20) { return 0.002; }
                if (d1 == 25) { return 0.002; }
                if (d1 == 30) { return 0.003; }
                if (d1 == 35) { return 0.005; }
                if (d1 == 40) { return 0.006; }
                if (d1 == 45) { return 0.007; }
                return 0.01;
            }
        }
    }
}
