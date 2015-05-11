using MachenicWpf.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MachenicWpf.Model {
    public class BaseViewModel : INotifyPropertyChanged {
        public DrawingType DrawingType { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        

        public virtual void NotifyChanged(string prop) {
            if (this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }

}
