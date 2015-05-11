using MachenicWpf.Model;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window {
        Type2ViewModel Model;
        public Window2(IType model) {
            InitializeComponent();
            Model = model as Type2ViewModel;
            DataContext = Model;
        }
        private void OnSave(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
            this.Close();
        }

        private void OnCancel(object sender, RoutedEventArgs e) {

        }
    }
}
