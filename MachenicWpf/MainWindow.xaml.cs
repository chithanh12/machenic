using MachenicWpf.Controls;
using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPageTransitions;

namespace MachenicWpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<IPageControl> pages = new List<IPageControl>();

        List<PageTransitionType> m_transition;
        public MainWindow() {
            InitializeComponent();
            m_transition = new List<PageTransitionType>();
            foreach (var item in Enum.GetValues(typeof(PageTransitionType))) {
                m_transition.Add((PageTransitionType)item);
            }
           
            
        }

        private void btnType1_Click(object sender, RoutedEventArgs e) {
            LoadForm(FormType.Type1);
            //_dropDownButton.IsOpen = false;
        }

        private void btnType2_Click(object sender, RoutedEventArgs e) {
            LoadForm(FormType.Type2);
            //_dropDownButton.IsOpen = false;
        }
        private void btnType3_Click(object sender, RoutedEventArgs e) {
            LoadForm(FormType.Type3);
            //_dropDownButton.IsOpen = false;
        }
        private void btnType4_Click(object sender, RoutedEventArgs e) {
            LoadForm(FormType.Type4);
            //_dropDownButton.IsOpen = false;
        }
        private void btnOrder_Click(object sender, RoutedEventArgs e) {
            LoadForm(FormType.Order);
            
        }
        private void btnStock_Click(object sender, RoutedEventArgs e) {
            LoadForm(FormType.StockPage);
        }
        private void LoadForm(FormType type) {
            var ran = new Random();

            var style = m_transition[0];
            pageTransitionControl.TransitionType = style;
            var page = pages.FirstOrDefault(x => x.FormType == type) as UserControl;
            pageTransitionControl.ShowPage(page);
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e) {
            //_dropDownButton.IsOpen = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            pages.Add(new Page1());
            pages.Add(new Page2());
            pages.Add(new Page3());
            pages.Add(new Page4());
            pages.Add(new PageOrder());
            pages.Add(new EditOrder());
            pages.Add(new StockPage());
            LoadForm(FormType.Order);
        }
    }
}
