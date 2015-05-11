using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class MaterialRow : INotifyPropertyChanged {
        private string m_formattedName { get; set; }
        private float m_cost;
        private float m_unitCost;
        private double? m_weight;

        public MaterialRow(string nameFormat) {
            m_formattedName = nameFormat;
        }
        
        public void SetParameter(params object[] objs){
            this.DisplayName = string.Format(m_formattedName, objs);
            NotifyChanged("DisplayName");
        }

        public string DisplayName { get; private set; }
        public int Id { get; set; }
        public float? Length {
            get {
                return m_length;
            }
            set {
                if (m_length != value) {
                    m_length = value;
                    NotifyChanged("Length");
                }
            }
        }
        public int Quantity { get; set; }
        public double? Weight {
            get {
                return m_weight;
            }
            set {
                if (m_weight != value) {
                    m_weight = value;
                    NotifyChanged("Weight");
                    NotifyChanged("Cost");
                }
            }
        }
        public string Unit { get; set; }
        public float UnitCost {
            get {
                return m_unitCost;
            }
            set {
                if (m_unitCost != value) {
                    m_unitCost = value;
                    NotifyChanged("UnitCost");
                    NotifyChanged("Cost");
                }
            }
        }
        public double Cost {
            get {
                return UnitCost * (Weight.GetValueOrDefault(0) == 0 ? 1 : Weight.Value) * Quantity;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private float? m_length;
        
        private void NotifyChanged(string prop) {
            if (this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }   
}
