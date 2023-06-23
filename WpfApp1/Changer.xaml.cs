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
using System.Windows.Shapes;

namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for Changer.xaml
    /// </summary>
    public partial class Changer : Window {
        public Changer() {
            InitializeComponent();
        }

        public Changer(FrameworkElement target) {
            lblb.Text = ((TextBlock)target).Text;
        }

        private void newwindow_Initialized(object sender, EventArgs e) {
            
        }
    }
}
