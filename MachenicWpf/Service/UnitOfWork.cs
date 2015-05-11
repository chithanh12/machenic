using MachenicWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MachenicWpf.Service {
    public class UnitOfWork : IDisposable {
        public const string ORDER = "Orders";
        public const string STOCK = "Stocks";

        private static MachenicContext m_context;
        private static int s_stockId;
        private static int s_orderId;
        private static UnitOfWork s_current;
        private static object m_object = new object();

        public static UnitOfWork Current {
            get {
                if (s_current == null) {
                    lock (m_object) {
                        if (s_current == null) {
                            s_current = new UnitOfWork();
                        }
                    }
                }
                return s_current;
            }
        }

        private UnitOfWork() {
            m_context = new MachenicContext();
            Init();
        }

        /// <summary>
        /// Get the lastest Id of each table
        /// </summary>
        static void Init() {
            s_stockId = 1;
            s_orderId = 1;
            //var order = m_context.Orders.FirstOrDefault();
            var ids = m_context.IDMasters.ToList();
            foreach (var id in ids) {
                if (id.TableName == STOCK) {
                    s_stockId = id.CurrentID + 1;
                } else if (id.TableName == ORDER) {
                    s_orderId = id.CurrentID + 1;
                }
            }
            if (ids.Count == 0) {
                m_context.IDMasters.Add(new IDMaster { TableName = ORDER, CurrentID = 0 });
                m_context.IDMasters.Add(new IDMaster { TableName = STOCK, CurrentID = 0 });
                m_context.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int GenerateStockId() {
            return ++s_stockId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int GenerateOrderId() {
            return ++s_orderId;
        }

        public void InsertOrder(Order order) {
            order.ID = GenerateOrderId();
            m_context.Orders.Add(order);
            m_context.SaveChanges();
        }

        public void UpdateOrder(Order order) {
            var db = m_context.Orders.FirstOrDefault(x => x.ID == order.ID);
            db.OrderType = order.OrderType;
            db.OrderNo = order.OrderNo;
            db.OrderDetail = order.OrderDetail;
            db.Quantity = order.Quantity;
            db.ToDate = order.ToDate;
            db.FromDate = order.FromDate;
            db.CustomerName = order.CustomerName;
            db.Finish = order.Finish;
            m_context.SaveChanges();
        }

        public void DeleteOrder(int orderId) {
            var db = m_context.Orders.FirstOrDefault(x => x.ID == orderId);
            m_context.Orders.Remove(db);
            m_context.SaveChanges();
        }

        public Order GetOrder(int orderId) {
            return m_context.Orders.FirstOrDefault(x => x.ID == orderId);
        }
        public void DeleteStock(int id) {
            throw new NotImplementedException();
        }
        public IList<Order> GetOrders(string customerName, bool finish = false) {

            Expression<Func<Order, bool>> ex = x => true;
            if (!string.IsNullOrEmpty(customerName)) {
                ex = ex.And(x => x.CustomerName.Contains(customerName));
            }
            return m_context.Orders.Where(ex).ToList();
            //return new List<Order>();
        }
        public IList<Stock> GetStocks(string stockName, int quantity) {

            Expression<Func<Stock, bool>> ex = x => true;
            if (!string.IsNullOrEmpty(stockName)) {
                ex = ex.And(x => x.Material.Contains(stockName));
            }
            if (quantity == 0) {
                ex = ex.And(x => x.Quantity == 0);
            } else {
                ex = ex.And(x => x.Quantity >= quantity);
            }
            return m_context.Stocks.Where(ex).ToList();
        }
        public void Dispose() {
            var ids = m_context.IDMasters.ToList();
            foreach (var id in ids) {
                if (id.TableName == STOCK) {
                    id.CurrentID = s_stockId;
                } else if (id.TableName == ORDER) {
                    id.CurrentID = s_orderId;
                }
            }
            m_context.SaveChanges();
            m_context.Dispose();
        }
    }
}
