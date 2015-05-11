using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class OrderViewModel : BaseViewModel, IDataErrorInfo {
        public ObservableCollection<MaterialRow> Materials { get; set; }
        public OrderViewModel() {
            Materials = new ObservableCollection<MaterialRow>();
            FromDate = DateTime.Now;
            ToDate = DateTime.Now.AddDays(10);
            SelectedType = 0;
            Quantity = 1;
            AvailableTypes = new List<DisplayItem> { 
                new DisplayItem{ Value = 1, Text ="Type 1"},
                new DisplayItem{ Value = 2, Text ="Type 2"},
                new DisplayItem{ Value = 3, Text ="Type 3"}
            };
            
        }

        private string m_orderNo;
        public IType TypeModel { get; set; }
        private string m_customerName;
        private int m_quantity;
        private float m_cost;
        private DateTime m_fromDate;
        private DateTime m_toDate;
        private bool m_finish;
        private int m_selectedType;
        private string m_orderDetail;
        private string m_address;
        public string OrderDetail {
            get { return m_orderDetail; }
            set {
                m_orderDetail = value;
                NotifyChanged("OrderDetail");
            }
        }
        public List<DisplayItem> AvailableTypes {
            get;
            set;
        }
        public int ID { get; set; }
        public string OrderNo {
            get {
                return m_orderNo;
            }
            set {
                if (m_orderNo != value) {
                    m_orderNo = value;
                    NotifyChanged("OrderNo");
                }
            }
        }
        public string CustomerName {
            get {
                return m_customerName;
            }
            set {
                if (m_customerName != value) {
                    m_customerName = value;
                    NotifyChanged("CustomerName");
                }
            }
        }
        public int Quantity {
            get {
                return m_quantity;
            }
            set {
                if (m_quantity != value) {
                    m_quantity = value;
                    NotifyChanged("Quantity");
                }
            }

        }
        public string Address {
            get {
                return m_address;
            }
            set {
                if (m_address != value) {
                    m_address = value;
                    NotifyChanged("Address");
                }
            }
        }
        public float Cost {
            get {
                return m_cost;
            }
            set {
                if (m_cost != value) {
                    m_cost = value;
                    NotifyChanged("Cost");
                }
            }
        }
        public DateTime FromDate {
            get {
                return m_fromDate;
            }
            set {
                if (m_fromDate != value) {
                    m_fromDate = value;
                    NotifyChanged("FromDate");
                }
            }
        }
        public DateTime ToDate {
            get {
                return m_toDate;
            }
            set {
                if (m_toDate != value) {
                    m_toDate = value;
                    NotifyChanged("ToDate");
                }
            }
        }
        public int RemainDate {
            get {
                return m_toDate.Subtract(DateTime.Now).Days;
            }
        }
        public bool Finish {
            get {
                return m_finish;
            }
            set {
                if (m_finish != value) {
                    m_finish = value;
                    NotifyChanged("Finish");
                }
            }
        }
        public int SelectedType {
            get {
                return m_selectedType;
            }
            set {
                if (m_selectedType != value) {
                    m_selectedType = value;
                    NotifyChanged("SelectedType");
                    if (value == 1) {
                        TypeModel = new Type1ViewModel();
                    } if (value == 2) {
                        TypeModel = new Type2ViewModel();
                    } else if (value == 3) {
                        TypeModel = new Type3ViewModel();
                    }
                    else {
                        //throw new NotImplementedException();
                        Materials.Clear();
                        return;
                    }
                    //TODO:
                    foreach (var item in Materials) {
                        item.PropertyChanged -= item_PropertyChanged;
                    }
                    Materials.Clear();
                    Materials.Add(TypeModel.ShaftRow);
                    Materials.Add(TypeModel.RollerPineRow);
                    Materials.Add(TypeModel.BearingStandRow);
                    Materials.Add(TypeModel.BearingRow);
                    Materials.Add(TypeModel.SealRow);
                    Materials.Add(TypeModel.CirclipRow);
                    foreach (var item in Materials) {
                        item.PropertyChanged += item_PropertyChanged;
                    }
                }
            }
        }

        void item_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            CostChanged();
        }
        private void CostChanged() {
            this.OrderDetail = this.TypeModel.ToOrderDetail();
        }
        public string Error {
            get {
                var error = string.Join("", this["OrderNo"], this["CustomerName"], this["OrderDetail"]);
                return error;
            }
        }
        public string this[string columnName] {
            get {
                string rs = "";
                if (columnName == "OrderNo") {
                    if (string.IsNullOrEmpty(this.OrderNo)) {
                        rs = "OrderNo can't be empty!";
                    }
                }
                if (columnName == "CustomerName") {
                    if (string.IsNullOrEmpty(this.CustomerName)) {
                        rs = "Customer Name is empty!";
                    }
                }

                if (columnName == "OrderDetail") {
                    if (string.IsNullOrEmpty(this.OrderDetail)) {
                        rs = "Drawing Values is empty!";
                    }
                }
                return rs;
            }
        }

        public static OrderViewModel Convert(Order order) {
            var rs = new OrderViewModel {
                ID = order.ID,
                Cost = order.Cost,
                CustomerName = order.CustomerName,
                Finish = order.Finish,
                FromDate = order.FromDate,
                ToDate = order.ToDate,
                OrderNo = order.OrderNo,
                Quantity = order.Quantity,
                SelectedType = order.OrderType,
                Address = order.Address
            };
            rs.OrderDetail = order.OrderDetail;
            if (!string.IsNullOrEmpty(order.OrderDetail)) {
                rs.TypeModel.RevertModel(order.OrderDetail);
            }
            return rs;
        }
        public double Total {
            get {
                double rs = 0;
                foreach (var item in Materials) {
                    rs += item.Cost;
                }
                return rs;
            }
        }
        public double TotalOrder {
            get {
                return Total * Quantity;
            }
        }
    }

    public class DisplayItem {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
