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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MachenicWpf.Controls {
    /// <summary>
    /// Interaction logic for StockPage.xaml
    /// </summary>
    public partial class StockPage : UserControl, IPageControl {
        
        public Utils.FormType FormType {
            get {
                return Utils.FormType.StockPage;
            }
        }
        private StockPageViewModel ModelContext { get; set; }
        public StockPage() {
            InitializeComponent();
            ModelContext = new StockPageViewModel();
            DataContext = ModelContext;
            SeachClick(null, null);
        }
        

        private void SeachClick(object sender, RoutedEventArgs e) {
            var items = UnitOfWork.Current.GetStocks(ModelContext.Criteria.Material, ModelContext.Criteria.Quantity);
            ModelContext.UpdateSources(items);
        }

        private void CreateNewMaterial(object sender, RoutedEventArgs e) {
            var form = new StockForm();
            form.ShowDialog();
            SeachClick(null, null);
        }

        private void OnEditMaterial(object sender, RoutedEventArgs e) {
            int ID = (int) ((Button)sender).CommandParameter;
            var form = new StockForm(ID);
            form.ShowDialog();
            SeachClick(null, null);
        }

        private void OnDeleteMaterial(object sender, RoutedEventArgs e) {
            int ID = (int)((Button)sender).CommandParameter;
            if (MessageBox.Show("Do you want to delete this material?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                UnitOfWork.Current.DeleteStock(ID);
                SeachClick(null, null);
            }
        }
    }
}
