using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public abstract class BaseTypeViewModel : BaseViewModel, IType, IDataErrorInfo {
        #region Fields
        private float m_d1;
        private float? m_l;
        private float m_b;
        private int m_bearing;
        private bool m_isValid;
        private float m_d;
        private float m_D1;
        #endregion
        public BaseTypeViewModel() {
            InitMaterial();
            DiameterList = ItemSourcesProvider.GetDiameters();
            BearingList = new ObservableCollection<int>();
            D = DiameterList.First();
           
        }
        #region Common Properties
        public bool IsValid {
            get {
                return m_isValid;
            }
            set {
                if (m_isValid != value) {
                    m_isValid = value;
                    NotifyChanged("IsValid");
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
                }
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
        public float? L {
            get { return m_l; }
            set {
                if (m_l != value) {
                    m_l = value;
                    NotifyChanged("L");
                }
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
        #endregion Common Properties
        public List<float> DiameterList { get; set; }
        public ObservableCollection<int> BearingList { get; set; }
        public string Error {
            get {
                StringBuilder err = new StringBuilder();
                foreach (var item in ValidateProperties()) {
                    err.Append(Validate(item));
                }
                return err.ToString();
            }
        }

        public string this[string columnName] {
            get {
                var str= Validate(columnName);
                IsValid = string.IsNullOrEmpty(str) && InternalValidate();
                return str;
            }
        }

        protected abstract string Validate(string propertyName);

        public abstract Dictionary<string, object> GetAllValues();

        public abstract string ToOrderDetail(bool store = false);

        public abstract void RevertModel(string detail);

        public MaterialRow ShaftRow { get; set; }
        public MaterialRow RollerPineRow { get; set; }
        public MaterialRow BearingStandRow { get; set; }
        public MaterialRow BearingRow { get; set; }
        public MaterialRow SealRow { get; set; }
        public MaterialRow CirclipRow { get; set; }
       
        public abstract string WeightOfRoller();
        private void InitMaterial() {
            ShaftRow = new MaterialRow("Shaft Ø{0}") { Id = 1, Quantity = 1, Unit = "kg" };
            RollerPineRow = new MaterialRow("Roller pipe Ø{0} x {1}") { Id = 2, Quantity = 1, Unit = "kg" };
            BearingStandRow = new MaterialRow("Bearing stand {0}-{1}") { Id = 3, Quantity = 2, Unit = "kg" };
            BearingRow = new MaterialRow("Bearing {0}") { Id = 4, Quantity = 2, Unit = "pcs" };
            SealRow = new MaterialRow("Seal for bearing {0}") { Id = 5, Quantity = 2, Unit = "pcs" };
            CirclipRow = new MaterialRow("Circlip for shaft Ø{0}") { Id = 6, Quantity = 2, Unit = "pcs" };
        }
        protected virtual List<string> ValidateProperties() {
            return new List<string> {
                "L"
            };
        }
        protected virtual bool InternalValidate() {
            return L.HasValue;
        }
        public override void NotifyChanged(string prop) {
            base.NotifyChanged(prop);
            RefreshMaterial();
        }
        protected abstract void RefreshMaterial();
    }
}
