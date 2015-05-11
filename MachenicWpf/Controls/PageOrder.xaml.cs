using MachenicWpf.Model;
using MachenicWpf.Service;
using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MachenicWpf.Controls {
    /// <summary>
    /// Interaction logic for PageOrder.xaml
    /// </summary>
    public partial class PageOrder : UserControl, IPageControl {
        private OrderService m_service;
        private OrderPageViewModel ModelContext { get; set; }
        public PageOrder() {
            InitializeComponent();
            ModelContext = new OrderPageViewModel();
            DataContext = ModelContext;
            m_service = new OrderService();
            SeachClick(null, null);
        }


        public Utils.FormType FormType {
            get {
                return Utils.FormType.Order;
            }
        }

        private void SeachClick(object sender, RoutedEventArgs e) {
            var items = UnitOfWork.Current.GetOrders(ModelContext.Criteria.CustomerName, ModelContext.Criteria.HasFinish);
            ModelContext.UpdateSources(items);
        }

        private void CreateNewOrder(object sender, RoutedEventArgs e) {
            var orderForm = new CreateOrder();
            orderForm.ShowDialog();
            SeachClick(null, null);
        }

        private void OnEditOrder(object sender, RoutedEventArgs e) {
            int ID = (int)((Button)sender).CommandParameter;
            var orderForm = new CreateOrder(ID);
            orderForm.ShowDialog();
            SeachClick(null, null);
        }

        private void OnDeleteOrder(object sender, RoutedEventArgs e) {
            int ID = (int)((Button)sender).CommandParameter;
            if (MessageBox.Show("Do you want to delete this order?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                UnitOfWork.Current.DeleteOrder(ID);
                SeachClick(null, null);
            }
        }
        private void OnDownloadDrawing(object sender, RoutedEventArgs e) {
            int ID = (int)((Button)sender).CommandParameter;
            var order = UnitOfWork.Current.GetOrder(ID);
            var model = new OrderViewModel {
                ID = order.ID,
                Cost = order.Cost,
                CustomerName = order.CustomerName,
                Finish = order.Finish,
                FromDate = order.FromDate,
                ToDate = order.ToDate,
                OrderNo = order.OrderNo,
                Quantity = order.Quantity,
                SelectedType = order.OrderType
            };
            if (!string.IsNullOrEmpty(order.OrderDetail)) {
                model.TypeModel.RevertModel(order.OrderDetail);
            }
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = " pdf (*.pdf)|*.pdf|All files (*.*)|*.*";
            var allData = model.TypeModel.GetAllValues();
            dialog.FileName = string.Format("RL.{0}.{1}.{2}.pdf", allData["D"], allData["L"], allData["Bearing"]);
            if (dialog.ShowDialog().GetValueOrDefault(false)) {
                PdfHelper.Export(model.SelectedType, model.TypeModel, order, dialog.FileName);
            }
            ;
        }

        private void OrderGrid_SelectionChanged(object sender, Xceed.Wpf.DataGrid.DataGridSelectionChangedEventArgs e) {
            var order = OrderGrid.SelectedItem as Order;
            ModelContext.SelectedOrder = order == null ? null : OrderViewModel.Convert(order);
        }

    }
}
