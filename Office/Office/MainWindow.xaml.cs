using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Office {
    /// <summary>
    /// Interaction logic for MainWindow.xaml 홍길동
    /// </summary>
    /// 

    public partial class MainWindow : Window {        

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            List<Office> Rooms = new List<Office>();
            Rooms.Add(new Office { Name = "이지원", Width = 10, Height = 10, Area = 100, Tiles = 10 });
            Rooms.Add(new Office { Name = "김동휘", Width = 20, Height = 10, Area = 100, Tiles = 10 });
            Rooms.Add(new Office { Name = "박연택", Width = 30, Height = 10, Area = 100, Tiles = 10 });

            OfficeList.ItemsSource = Rooms;
        }
    }

    public class Office {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Area { get; set; }
        public int Tiles { get; set; }
    }
}
