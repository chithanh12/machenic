using MachenicWpf.Model;
using MachenicWpf.Service;
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
using System.Windows.Shapes;

namespace MachenicWpf.Controls {
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window {
        private OrderViewModel Model { get; set; }
        public CreateOrder() {
            Model = new OrderViewModel();
            DataContext = Model;
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        public CreateOrder(int id) {
            var order = UnitOfWork.Current.GetOrder(id);
            Model = OrderViewModel.Convert(order);
            DataContext = Model;
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            
        }

        private void OnSave(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrEmpty(Model.Error)) {
                MessageBox.Show("Please fill all data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var order = new Order {
                Cost = Model.Cost,
                CustomerName = Model.CustomerName,
                Finish = Model.Finish,
                FromDate = Model.FromDate,
                OrderNo = Model.OrderNo,
                OrderType = Model.SelectedType,
                ToDate = Model.ToDate,
                Quantity = Model.Quantity,
                ID = Model.ID,
                OrderDetail = Model.OrderDetail,
                Address = Model.Address
            };
            if (order.ID > 0) {
                UnitOfWork.Current.UpdateOrder(order);
            } else {
                UnitOfWork.Current.InsertOrder(order);
            }
            
            this.Close();
        }

        private void ShowDrawingDialog(object sender, RoutedEventArgs e) {

        }

        private void OnClose(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void OnSelectDrawingValues(object sender, RoutedEventArgs e) {
            if (Model.SelectedType == 1) {
                var form = new Window1(Model.TypeModel);
                form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                if (form.ShowDialog().GetValueOrDefault(false)) {
                    Model.OrderDetail = Model.TypeModel.ToOrderDetail();
                }
            } if (Model.SelectedType == 2) {
                var form = new Window2(Model.TypeModel);
                form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                if (form.ShowDialog().GetValueOrDefault(false)) {
                    Model.OrderDetail = Model.TypeModel.ToOrderDetail();
                }
            } else {
                MessageBox.Show("Comming soon!", "Infor", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //private void SelectedTypeChanged(object sender, SelectionChangedEventArgs e) {
        //    if (Model.SelectedType == 1) {
        //        var form = new Window1(Model.TypeModel);
        //        if (form.ShowDialog().GetValueOrDefault(false)) {
        //            Model.OrderDetail = Model.TypeModel.ToOrderDetail();
        //        }
        //    } else if (Model.SelectedType > 0) {
        //        MessageBox.Show("Comming soon!", "Infor", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //}
    }
}
