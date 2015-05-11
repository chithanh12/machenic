using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MachenicWpf.Controls {
    public class NumericTextBox : TextBox {

        public string ErrorMessage {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(NumericTextBox), new PropertyMetadata(""));

        
        public float? MinValue {
            get { return (float?)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public float? MaxValue {
            get { return (float?)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(float?), typeof(NumericTextBox), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(float?), typeof(NumericTextBox), new PropertyMetadata(null));

        public NumericTextBox() {
            this.TextAlignment = System.Windows.TextAlignment.Right;
            this.BorderThickness = new Thickness(1);
            this.PreviewTextInput += NumericTextBox_PreviewTextInput;
        }

        void NumericTextBox_PreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) {
            //ClearError();
            //if (this.MinValue.HasValue && !string.IsNullOrEmpty(this.Text)) {
            //    if (float.Parse(Text) < MinValue.Value) {
            //        e.Handled = true;
            //        this.ErrorMessage = "Value must be less than" + MinValue.Value;
            //        this.Focus();
            //        this.RaiseError();
            //        return;
            //    }

            //}
            //if (this.MaxValue.HasValue && !string.IsNullOrEmpty(this.Text)) {
            //    if (float.Parse(Text) < MinValue.Value) {
            //        e.Handled = true;
                   
            //        this.Focus();
            //        return;
            //    }

            //}
        }

        void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
    }
}
