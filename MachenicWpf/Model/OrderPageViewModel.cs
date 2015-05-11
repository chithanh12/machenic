using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class OrderPageViewModel : BaseViewModel {
        private OrderViewModel m_order;
        public OrderCriteria Criteria { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public OrderPageViewModel() {
            Criteria = new OrderCriteria();
            Orders = new ObservableCollection<Order>();
        }

        public void UpdateSources(IList<Order> order) {
            Orders.Clear();
            foreach (var item in order) {
                Orders.Add(item);
            }
        }
        public OrderViewModel SelectedOrder {
            get {
                return m_order;
            }
            set {
                m_order = value;
                NotifyChanged("SelectedOrder");
            }
        }
        
    }
    public class OrderCriteria : BaseViewModel {
        private string m_customerName;
        private bool m_finish;
        private string m_orderNo;
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
        public bool HasFinish {
            get {
                return m_finish;
            }
            set {
                if (m_finish != value) {
                    m_finish = value;
                    NotifyChanged("HasFinish");
                }
            }
        }

    }
}
