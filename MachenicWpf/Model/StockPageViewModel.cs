using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class StockPageViewModel : BaseViewModel{
        public StockCriteria Criteria { get; set; }
        public ObservableCollection<Stock> Stocks { get; set; }
        public StockPageViewModel() {
            Criteria = new StockCriteria();
            Stocks = new ObservableCollection<Stock>();
        }

        public void UpdateSources(IList<Stock> order) {
            Stocks.Clear();
            foreach (var item in order) {
                Stocks.Add(item);
            }
        }

    }
    public class StockCriteria : BaseViewModel {
        private int m_quantity;
        private string m_material;
        public string Material {
            get {
                return m_material;
            }
            set {
                if (m_material != value) {
                    m_material = value;
                    NotifyChanged("OrderNo");
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
                    NotifyChanged("CustomerName");
                }
            }
        }

    }
}
