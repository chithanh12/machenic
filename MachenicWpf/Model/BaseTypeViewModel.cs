using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public abstract class BaseTypeViewModel : BaseViewModel, IType, IDataErrorInfo {
        private float m_d1;
        private float? m_l;
        private float m_b;
        private int m_bearing;
        private bool m_isValid;
        private float m_d;
        private float m_D1;

        public BaseTypeViewModel() {
            InitMaterial();
            DiameterList = ItemSourcesProvider.GetDiameters();
            BearingList = new ObservableCollection<int>();
            D = DiameterList.First();
           
        }
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
