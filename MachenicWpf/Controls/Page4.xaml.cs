﻿using System;
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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : UserControl, IPageControl {
        public Page4() {
            InitializeComponent();
        }

        public Utils.FormType FormType {
            get {
                return Utils.FormType.Type4;
            }
        }
    }
}
